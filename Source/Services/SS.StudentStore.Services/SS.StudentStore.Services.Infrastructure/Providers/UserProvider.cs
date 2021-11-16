using Microsoft.Data.SqlClient;
using SS.StudentStore.Services.Core.Constants;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public class UserProvider : BaseProvider<Users>, IUserProvider
    {
        private const string SCHEMA = Constant.Schema_AppIdentity;
        public UserProvider(AppIdentityDBContext dbContext) : base(dbContext) { }
        public async Task<UserView> AddUser(Users user, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@userId", user.UserId.GetValueOrDefault() == 0 ? (object)DBNull.Value : user.UserId.Value) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@firstName", string.IsNullOrEmpty(user.FirstName) ? (object)DBNull.Value : user.FirstName) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@middleName", string.IsNullOrEmpty(user.MiddleName)? (object)DBNull.Value : user.MiddleName) { SqlDbType = SqlDbType.NVarChar, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@lastName", string.IsNullOrEmpty(user.LastName)? (object)DBNull.Value : user.LastName) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@displayName", user.DisplayName) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@userName", string.IsNullOrEmpty(user.UserName) ? user.Email: user.UserName ) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@email", user.Email) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@phoneNumber", string.IsNullOrEmpty(user.PhoneNumber) ? (object)DBNull.Value : user.PhoneNumber) { SqlDbType = SqlDbType.NVarChar,IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@clearPassword", string.IsNullOrEmpty(user.ClearPassword)? (object)DBNull.Value : user.ClearPassword) { SqlDbType = SqlDbType.NVarChar,IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@passwordHash", string.IsNullOrEmpty(user.PasswordHash)? (object)DBNull.Value : user.PasswordHash) { SqlDbType = SqlDbType.NVarChar,IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@lastLoginDate", user.LastLoginDate.HasValue ? user.LastLoginDate : DateTime.Now) { SqlDbType = SqlDbType.DateTime,IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@isLocked", user.IsLocked == null? false : user.IsLocked) { SqlDbType = SqlDbType.Bit,IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@accessFailedCount", user.AccessFailedCount.GetValueOrDefault() == 0 ? (object)DBNull.Value : user.AccessFailedCount.Value ) { SqlDbType = SqlDbType.Int, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@isActive",  user.IsActive == null? true : user.IsActive) { SqlDbType = SqlDbType.Bit, IsNullable= true, Direction = ParameterDirection.Input},
            };

            var strParam = "@userId, @firstName, @middleName, @lastName, @displayName, @userName, @email, @phoneNumber, @clearPassword, @passwordHash, @lastLoginDate, @isLocked, @accessFailedCount, @isActive";
          
            return await this.ExecuteQueryForOtherEntity<UserView>(SCHEMA, "usp_AddOrUpdateUser", strParam, sqlParams, cancellationToken);
        }

        public async Task<UserView> AuthenticateUser(string email, string password, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@email", email) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@password", password) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
            };

            var strParam = "@email, @password";

            return await this.ExecuteQueryForOtherEntity<UserView>(SCHEMA, "usp_AuthenticateUser", strParam, sqlParams, cancellationToken);

        }

        public async Task<UserView> GetUser(int id, CancellationToken cancellationToken)
            => await this.ExecuteQueryForOtherEntity<UserView>(SCHEMA, "usp_GetUserById", "@userId", new SqlParameter("@userId", id), cancellationToken);

        public async Task<UserView> GetUserByEmail(string email, CancellationToken cancellationToken)
            => await this .ExecuteQueryForOtherEntity<UserView>(SCHEMA, "usp_GetUserByEmail", "@email", new SqlParameter("@email", email), cancellationToken);

        public async Task<UserView> GetUserByUserName(string userName, CancellationToken cancellationToken)
            => await this.ExecuteQueryForOtherEntity<UserView>(SCHEMA, "usp_GetUserByUserName", "@userName", new SqlParameter("@userName", userName), cancellationToken);

        public async Task<UserView> UpdateUser(Users user, CancellationToken cancellationToken)
            => await this.AddUser(user, cancellationToken);
        
    }
}
