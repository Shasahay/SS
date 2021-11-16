using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Extensions;
using SS.StudentStore.Services.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public abstract class BaseProvider<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        private readonly IConfiguration _configuration;

        #region Constructors
        public BaseProvider(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public BaseProvider(DbContext dbContext, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this._configuration = configuration;
        }
        #endregion

        #region Helper
        private async Task<IEnumerable<StoredProcParam>> GetStoredProcedureParameters(string schema, string storedProcedureName)
        {
            try
            {
                var paramSchema = new SqlParameter("schema", schema);
                var paramName = new SqlParameter("spName", storedProcedureName);

                var sqlQuery = $"SELECT PARAMETER_MODE, PARAMETER_NAME, DATA_TYPE, USER_DEFINED_TYPE_SCHEMA, USER_DEFINED_TYPE_NAME " +
                                $"FROM INFORMATION_SCHEMA.PARAMETERS " +
                                $"WHERE SPECIFIC_SCHEMA = @schema and specific_name = @spName " +
                                $"ORDER BY ORDINAL_POSITION";
                return await this._dbContext.Set<StoredProcParam>().FromSqlRaw(sqlQuery, paramSchema, paramName).ToListAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        private async Task<IEnumerable<CustomTableTypeColumn>> GetCustomTableTypeColumn(string schema, string customTableType)
        {
            try
            {
                var paramSchema = new SqlParameter("schema", schema);
                var paramCustomTableType = new SqlParameter("customTableType", customTableType);

                var sqlQuery = $"SELECT C.NAME AS COLUMN_NAME, T.NAME AS [TYPE_NAME], C.IS_NULLABLE AS [NULLABLE]" +
                                $"FROM SYS.COLUMNS C " +
                                $"INNER JOIN SYS.TYPES T " +
                                $"ON T.USER_TYPE_ID = C.USER_TYPE_ID " +
                                $"WHERE C.OBJECT_ID = (SELECT T.TYPE_TABLE_OBJECT_ID FROM SYS.TABLE_TYPES T " +
                                $"INNER JOIN SYS.SCHEMAS S ON T.schema_id = S.schema_id " +
                                $"WHERE S.name = @schema and T.name = @customTableType) " +
                                $"ORDER BY C.COLUMN_ID";
                return await this._dbContext.Set<CustomTableTypeColumn>().FromSqlRaw(sqlQuery, paramSchema, paramCustomTableType).ToListAsync();
            }
            catch (Exception ex) { throw ex; }

        }

        protected async Task<IList<SchemaTableType>> GetUserDefineTableParameters(string tableTypeName)
        {
            try
            {
                var paramName = new SqlParameter("tableName", tableTypeName);
                var sqlQuery = $"SELECT COL.name ColumnName, ST.name TypeName " +
                                $"FROM sys.table_types TYPE " +
                                $"JOIN sys.columns COL ON TYPE.type_table_object_id = COL.object_id " +
                                $"JOIN sys.systypes AS ST ON ST.xtype = COL.system_type_id " +
                                $"WHERE TYPE.is_user_defined = 1 AND ST.name <> 'sysname' AND TYPE.name = @tableName " +
                                $"RDER BY col.column_id";

                return await this._dbContext.Set<SchemaTableType>().FromSqlRaw(sqlQuery, paramName).ToListAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        protected async Task<SqlParameter> BuildTableParameter(StoredProcParam param, System.Collections.IEnumerable enumerableValues)
        {
            var table = new DataTable();
            List<string> columnNames = new List<string>();

            // Get the custom table column
            IEnumerable<CustomTableTypeColumn> customTableTypeColumns = await this.GetCustomTableTypeColumn(param.USER_DEFINED_TYPE_SCHEMA, param.USER_DEFINED_TYPE_NAME);
            foreach (CustomTableTypeColumn customTableTypeColumn in customTableTypeColumns)
            {
                table.Columns.Add(customTableTypeColumn.COLUMN_NAME, customTableTypeColumn.ToType());
                columnNames.Add(customTableTypeColumn.COLUMN_NAME); // Collection of columns to populate
            }

            // Create a dictionary of column name

            Dictionary<string, PropertyInfo> propList = null;
            Dictionary<string, object> propDefaultValue = null;

            // loop through the collection and add it to table

            foreach (var enumerableValue in enumerableValues)
            {
                var newRow = table.NewRow();

                if (propList == null)
                {
                    propList = new Dictionary<string, PropertyInfo>();
                    propDefaultValue = new Dictionary<string, object>();

                    var propInfos = enumerableValue.GetType().GetProperties();
                    foreach (var columnName in columnNames)
                    {
                        var propInfo = propInfos.FirstOrDefault(x => x.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));
                        if (propInfo == null)
                        {
                            foreach (var prop in propInfos)
                            {
                                var CustomAttr = prop.CustomAttributes.FirstOrDefault(x => x.AttributeType.Equals(typeof(ColumnAttribute)) && x.ConstructorArguments[0].Value.ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase));
                                if (CustomAttr != null)
                                {
                                    propInfo = prop;
                                    break;
                                }
                            }
                        }
                        if (propInfo == null)
                        {
                            throw new NotImplementedException($"Column {columnName} was not found an object {enumerableValue.GetType().FullName}");
                        }
                        // Add to property list
                        propList.Add(columnName, propInfo);
                        // If there is a default value
                        var defaultAttr = propInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Equals(typeof(DefaultValueAttribute)));
                        if (defaultAttr != null)
                        {
                            propDefaultValue.Add(columnName, defaultAttr.ConstructorArguments[0].Value);
                        }
                        else
                        {
                            propDefaultValue.Add(columnName, propInfo.ToDefaultValue(enumerableValue));
                        }
                    }
                }
                foreach (var columnName in columnNames)
                {
                    var value = propList[columnName].GetValue(enumerableValue);
                    newRow[columnName] = value ?? propDefaultValue[columnName];
                }
                table.Rows.Add(newRow);
            }

            return await Task.FromResult(new SqlParameter
            {
                ParameterName = param.PARAMETER_NAME,
                Value = table,
                TypeName = $"{param.USER_DEFINED_TYPE_SCHEMA}.{param.USER_DEFINED_TYPE_NAME}",
                SqlDbType = SqlDbType.Structured,
                Direction = param.ToParameterDirection()
            });

        }
        private async Task<(string, IEnumerable<SqlParameter>)> BuildParams<TType>(string schema, string storedProcedureName, TType data) where TType : class
        {
            var listRequest = new List<KeyValuePair<string, object>>();
            foreach (var pi in data.GetType().GetProperties())
            {
                var propName = pi.Name;
                var ca = pi.CustomAttributes.FirstOrDefault(x => x.AttributeType.Equals(typeof(ColumnAttribute)));
                if (ca != null)
                {
                    propName = ca.ConstructorArguments[0].Value.ToString();
                }
                listRequest.Add(new KeyValuePair<string, object>(propName, pi.GetValue(data, null)));
            }

            var sbParameters = new StringBuilder();
            var paramValues = new List<SqlParameter>();
            var spParameterDatas = await this.GetStoredProcedureParameters(schema, storedProcedureName);

            foreach (var spParameterData in spParameterDatas)
            {
                var paramValue = listRequest.FirstOrDefault(x => $"@{x.Key}".Equals(spParameterData.PARAMETER_NAME, StringComparison.OrdinalIgnoreCase));
                if (spParameterData.DATA_TYPE.ToUpper().Equals("TABLE TYPE"))
                {
                    if (paramValue.Value is System.Collections.IEnumerable enumerableValue)
                    {
                        var tableValuedParameter = this.BuildTableParameter(spParameterData, enumerableValue);
                        paramValues.Add(new SqlParameter
                        {
                            ParameterName = spParameterData.PARAMETER_NAME,
                            Value = await tableValuedParameter,
                            SqlDbType = SqlDbType.Structured,
                            Direction = spParameterData.ToParameterDirection()
                        });
                    }
                    else
                    {
                        paramValues.Add(new SqlParameter
                        {
                            ParameterName = spParameterData.PARAMETER_NAME,
                            Value = DBNull.Value,
                            SqlDbType = SqlDbType.Structured,
                            Direction = spParameterData.ToParameterDirection()
                        });
                    }
                }
                else
                {
                    paramValues.Add(new SqlParameter
                    {
                        ParameterName = spParameterData.PARAMETER_NAME,
                        Value = paramValue.Value ?? DBNull.Value,
                        SqlDbType = SqlDbType.Structured,
                        Direction = spParameterData.ToParameterDirection()
                    });
                }

                sbParameters.Append($"{spParameterData.PARAMETER_NAME} " + $"{((spParameterData.ToParameterDirection() == ParameterDirection.InputOutput || spParameterData.ToParameterDirection() == ParameterDirection.Output) ? "OUT" : "")},");
            }
            var strParam = sbParameters.ToString().Substring(0, sbParameters.Length - 1);
            return (strParam, paramValues);
        }
        private List<SqlParameter> AddReturnParameter(List<SqlParameter> sqlParams)
        {
            if (sqlParams.FindIndex(x => x.ParameterName.ToLower().Equals("@returnval")) < 0) // checking if return value is added 
            {
                sqlParams.Add(new SqlParameter("@returnval", SqlDbType.Int) { Direction = ParameterDirection.Output });
            }
            return sqlParams;
        }
        protected async Task<DataTable> CreateDataTable<TRequest>(string tableTypeName, IEnumerable<TRequest> requests)
        {
            var tbl = new DataTable();
            var columnParameters = await this.GetUserDefineTableParameters(tableTypeName);

            // Set data table column
            foreach (var columnParamter in columnParameters)
            {
                tbl.AddColumn(columnParamter.ColumnName, columnParamter.TypeName.ToType());
            }

            // Set data row 

            foreach (var request in requests)
            {
                var newRow = tbl.NewRow();
                foreach (var pi in request.GetType().GetProperties())
                {
                    var columnParameter = columnParameters.FirstOrDefault(x => x.ColumnName.Equals(pi.Name, StringComparison.OrdinalIgnoreCase));
                    if (columnParameter != null)
                    {
                        newRow[columnParameter.ColumnName] = pi.GetValue(request, null) ?? "";
                    }
                }
                tbl.Rows.Add(newRow);
            }
            return tbl;
        }
        #endregion

        #region Returning Single Entity
        protected async Task<TEntity> ExecuteQueryForEntity(string schema, string storedProcedureName, string strParam, SqlParameter sqlParam, CancellationToken cancellationToken)
        {
            var result = await this._dbContext.Set<TEntity>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParam).ToListAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        protected async Task<TEntity> ExecuteQueryForEntity(string schema, string storedProcedureName, string strParam, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken)
        {
            var result = await this._dbContext.Set<TEntity>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParams.ToArray()).ToListAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        protected async Task<TEntity> ExecuteQueryForEntity<Trequest>(string schema, string storedProcedureName, Trequest data, CancellationToken cancellationToken) where Trequest : class
        {
            var (strParam, sqlParams) = await this.BuildParams(schema, storedProcedureName, data);
            return await this.ExecuteQueryForEntity(schema, storedProcedureName, strParam, sqlParams, cancellationToken);
        }

        protected async Task<TType> ExecuteQueryForOtherEntity<TType>(string schema, string storedProcedureName, string strParam, SqlParameter sqlParam, CancellationToken cancellationToken) where TType : class
        {
            var result = await this._dbContext.Set<TType>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParam).ToListAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        protected async Task<TType> ExecuteQueryForOtherEntity<TType>(string schema, string storedProcedureName, string strParam, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken) where TType : class
        {
            var result = await this._dbContext.Set<TType>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParams.ToArray()).ToListAsync(cancellationToken);
            return result.FirstOrDefault();
        }

        protected async Task<TType> ExecuteQueryForOtherEntity<TType>(string schema, string storedProcedureName, TType data, CancellationToken cancellationToken) where TType : class
        {
            var (strParam, sqlParams) = await this.BuildParams(schema, storedProcedureName, data);
            return await this.ExecuteQueryForOtherEntity<TType>(schema, storedProcedureName, strParam, sqlParams, cancellationToken);
        }
        #endregion

        #region Return List of Entities
        protected async Task<IEnumerable<TEntity>> ExecuteQueryForEntities(string schema, string storedProcedureName, string strParam, SqlParameter sqlParam, CancellationToken cancellationToken)
            => await this._dbContext.Set<TEntity>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParam).ToListAsync(cancellationToken);

        protected async Task<IEnumerable<TEntity>> ExecuteQueryForEntities(string schema, string storedProcedureName, string strParam, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken)
            => await this._dbContext.Set<TEntity>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParams.ToArray()).ToListAsync(cancellationToken);

        protected async Task<IEnumerable<TEntity>> ExecuteQueryForEntities<Trequest>(string schema, string storedProcedureName, Trequest data, CancellationToken cancellationToken) where Trequest : class
        {
            var (strParam, sqlParams) = await this.BuildParams(schema, storedProcedureName, data);
            return await this.ExecuteQueryForEntities(schema, storedProcedureName, strParam, sqlParams, cancellationToken);
        }
        protected async Task<IEnumerable<TEntity>> ExecuteQueryForEntities(string schema, string storedProcedureName, CancellationToken cancellationToken)
            => await this._dbContext.Set<TEntity>().FromSqlRaw($"exec {schema}.{storedProcedureName}").ToListAsync(cancellationToken);
        protected async Task<IEnumerable<TEntity>> ExecuteQueryForEntitiesWithReturnVal(string schema, string storedProcedureName, CancellationToken cancellationToken)
            => await this._dbContext.Set<TEntity>().FromSqlRaw($"exec @returnval = {schema}.{storedProcedureName}", new SqlParameter("@returnval", SqlDbType.Int) { Direction = ParameterDirection.Output }).ToListAsync(cancellationToken);

        protected async Task<IEnumerable<TType>> ExecuteQueryForOtherEntities<TType>(string schema, string storedProcedureName, string strParam, SqlParameter sqlParam, CancellationToken cancellationToken) where TType : class
            => await this._dbContext.Set<TType>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParam).ToListAsync(cancellationToken);

        protected async Task<IEnumerable<TType>> ExecuteQueryForOtherEntities<TType>(string schema, string storedProcedureName, CancellationToken cancellationToken) where TType : class
            => await this._dbContext.Set<TType>().FromSqlRaw($"exec {schema}.{storedProcedureName}").ToListAsync(cancellationToken);


        protected async Task<IEnumerable<TType>> ExecuteQueryForOtherEntities<TType>(string schema, string storedProcedureName, string strParam, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken) where TType : class
            => await this._dbContext.Set<TType>().FromSqlRaw($"exec {schema}.{storedProcedureName} {strParam}", sqlParams.ToArray()).ToListAsync(cancellationToken);

        // Check following method later 
        //protected async Task<IEnumerable<TType>> ExecuteQueryForOtherEntities<TType>(string schema, string storedProcedureName, CancellationToken cancellationToken) where TType : class
        //    => await this._dbContext.Set<TType>().FromSqlRaw($"exec @returnval =  {schema}.{storedProcedureName}", new SqlParameter("@returnval", SqlDbType.Int) { Direction = ParameterDirection.Output }).ToListAsync(cancellationToken);
        #endregion

        protected async Task<bool> ExecuteNonQuery(string schema, string storedProcedure, string strParam, SqlParameter sqlParameter, CancellationToken cancellationToken)
            => await this.ExecuteNonQuery(schema, storedProcedure, strParam, new List<SqlParameter>() { sqlParameter}, cancellationToken);
        protected async Task<bool> ExecuteNonQuery(string schema, string storedProcedure, string strParam, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken, TimeSpan? customTimeout = null)
        {
            var updateSqlParams = this.AddReturnParameter(sqlParams.ToList());
            //this._dbContext.Database.SetCommandTimeout(this._configuration == null ? (customTimeout == null ? new TimeSpan(0, 0, 0) : customTimeout.Value) : (new TimeSpan(this._configuration.GetValue<int>("Timeoutlapse:ExecuteNonQuery:Hours"), this._configuration.GetValue<int>("TimeoutLapse:ExecuteNonQuery:Minute"), this._configuration.GetValue<int>("TimeoutLapse:ExecuteNonQuery:Minute"))));
            this._dbContext.Database.SetCommandTimeout(60);
            await this._dbContext.Database.ExecuteSqlRawAsync($"exec @returnval = {schema}.{storedProcedure} {strParam}", updateSqlParams, cancellationToken).ConfigureAwait(false);
            return updateSqlParams.FirstOrDefault(x => x.ParameterName.ToLower().Equals("@returnval")).Value.Equals(0);
        }
        protected async Task<bool> ExecuteNonQuery<Trequest>(string schema, string storedProcedureName, Trequest data, CancellationToken cancellationToken) where Trequest : class
        {
            var (strParam, sqlParams) = await this.BuildParams(schema, storedProcedureName, data);
            return await this.ExecuteNonQuery(schema, storedProcedureName, strParam, sqlParams, cancellationToken);
        }
        protected async Task<DataTable> GetDataTableUsingReaderAsync(string schema, string storedProcedureName, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken)
        {
            var result = new DataTable();
            var sqlConnection = (SqlConnection)this._dbContext.Database.GetDbConnection();
            var sqlCommand = new SqlCommand($"{schema}.{storedProcedureName}", sqlConnection) { CommandType = CommandType.StoredProcedure };
            if(sqlParams.Any())
            {
                sqlCommand.Parameters.AddRange(sqlParams.ToArray());
            }
            try
            {
                await sqlConnection.OpenAsync(cancellationToken);
                var queryResult = await sqlCommand.ExecuteReaderAsync(cancellationToken);
                result.Load(queryResult);
                sqlConnection.Close();
                return result;
            }
            catch(Exception ex) { throw ex; }
            finally
            {
                if(sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }
        protected async Task<TType> ExecuteScalarAsync<TType>(string schema, string storedProcedureName, IEnumerable<SqlParameter> sqlParams, CancellationToken cancellationToken)
        {
            var sqlConnection = (SqlConnection)this._dbContext.Database.GetDbConnection();
            var sqlCommand = new SqlCommand($"{schema}.{storedProcedureName}", sqlConnection) { CommandType = CommandType.StoredProcedure };
            if (sqlParams.Any())
            {
                sqlCommand.Parameters.AddRange(sqlParams.ToArray());
            }
            try
            {
                await sqlConnection.OpenAsync(cancellationToken);
                var result = await sqlCommand.ExecuteScalarAsync(cancellationToken);
                sqlConnection.Close();
                return (TType)result;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }

        }
    }
}
