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
    public class StagingProductProvidercs : BaseProvider<StagingProduct>, IStagingProductProvider
    {
        private const string SCHEMA = Constant.Schema_Staging;
        public StagingProductProvidercs(StagingDBContext dbContext) : base(dbContext) { }

        public async Task<StagingProductView> AddOrUpdateProduct(StagingProduct sProduct, string userEmail, CancellationToken cancellationToken)
        {
            var v = sProduct.ProductUID;
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@productId", sProduct.ProductId.GetValueOrDefault() == 0 ? (object)DBNull.Value : sProduct.ProductId) { SqlDbType = SqlDbType.BigInt, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@productUID", sProduct.ProductUID == Guid.Empty ? Guid.NewGuid() : sProduct.ProductUID) { SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input},
                new SqlParameter("@title", String.IsNullOrEmpty(sProduct.Title) ? (object)DBNull.Value : sProduct.Title) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@name", String.IsNullOrEmpty(sProduct.Name) ? (object)DBNull.Value : sProduct.Name) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@description", String.IsNullOrEmpty(sProduct.Description) ? (object)DBNull.Value : sProduct.Description) { SqlDbType = SqlDbType.NVarChar, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@price", sProduct.Price == 0 ? (object)DBNull.Value : sProduct.Price) { SqlDbType = SqlDbType.Decimal, IsNullable= true, Direction = ParameterDirection.Input},
                new SqlParameter("@categoryId", sProduct.CategoryId == 0 ? (object)DBNull.Value : sProduct.CategoryId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@subCategoryId", sProduct.SubCategoryId == 0 ? (object)DBNull.Value : sProduct.SubCategoryId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@gradeId", sProduct.GradeId == 0 ? (object)DBNull.Value : sProduct.GradeId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@sectionId", sProduct.SectionId == 0 ? (object)DBNull.Value : sProduct.SectionId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@brandId", sProduct.BrandId == 0 ? (object)DBNull.Value : sProduct.BrandId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@shortPictureUrl", String.IsNullOrEmpty(sProduct.ShortPictureUrl) ? (object)DBNull.Value : sProduct.ShortPictureUrl) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@pictureUrl", String.IsNullOrEmpty(sProduct.PictureUrl) ? (object)DBNull.Value : sProduct.PictureUrl) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@productManufacturer", String.IsNullOrEmpty(sProduct.ProductManufacturer) ? userEmail : sProduct.ProductManufacturer) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@productManufacturerPicture", String.IsNullOrEmpty(sProduct.ProductManufacturerPicture) ? (object)DBNull.Value : sProduct.ProductManufacturerPicture) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@productManufacturerProfile", String.IsNullOrEmpty(sProduct.ProductManufacturerProfile) ? (object)DBNull.Value : sProduct.ProductManufacturerProfile) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@documentUrl", String.IsNullOrEmpty(sProduct.DocumentUrl) ? (object)DBNull.Value : sProduct.DocumentUrl) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
                new SqlParameter("@documentType", sProduct.DocumentType == 0 ? (object)DBNull.Value : sProduct.DocumentType) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@statusId", sProduct.StatusId == 0 ? (object)DBNull.Value : sProduct.StatusId) { SqlDbType = SqlDbType.Int, IsNullable = true, Direction = ParameterDirection.Input},
                new SqlParameter("@isActive",  sProduct.IsActive == null? true : sProduct.IsActive) { SqlDbType = SqlDbType.Bit, IsNullable= true, Direction = ParameterDirection.Input},
                
            };

            var strParam = "@productId, @productUID, @title, @name, @description, @price, @categoryId, @subCategoryId, @gradeId, @sectionId, @brandId, @shortPictureUrl, @pictureUrl, @productManufacturer, @productManufacturerPicture, @productManufacturerProfile, @documentUrl, @documentType, @statusId, @isActive";

            return await this.ExecuteQueryForOtherEntity<StagingProductView>(SCHEMA, "[usp_AddorUpdateProduct]", strParam, sqlParams, cancellationToken);
        }

        public async Task<IEnumerable<StagingProductView>> GetAllProduct(string UserEmail, CancellationToken cancellationToken)
            => await this.ExecuteQueryForOtherEntities<StagingProductView>(SCHEMA, "[usp_GetProductByUser]", "@userEmail", new SqlParameter("@userEmail", UserEmail), cancellationToken);

        public async Task<StagingProductView> GetProduct(long productId, string userEmail, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@productId", productId) { SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Input},
                new SqlParameter("@userEmail", userEmail) { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
            };

            var strParam = "@productId, @userEmail";

            return await this.ExecuteQueryForOtherEntity<StagingProductView>(SCHEMA, "[usp_GetProductById]", strParam, sqlParams, cancellationToken);

        }

    }
}
