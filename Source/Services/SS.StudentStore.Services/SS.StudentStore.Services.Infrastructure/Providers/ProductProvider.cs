using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Constants;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Extensions;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Infrastructure.DBContext;
using SS.StudentStore.Services.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public class ProductProvider : BaseProvider<Product>, IProductProvider
    {

        private const string SCHEMA = Constant.Schema_Core;

        public ProductProvider(CoreDBContext dbContext) : base(dbContext) { }
        public Task<Product> Add(Product product, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<bool> Delete(int id, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ProductView> GetProduct(long id, CancellationToken cancellationToken)
            => this.ExecuteQueryForOtherEntity<ProductView>(SCHEMA, "usp_GetProductById", "@id", new SqlParameter("@id", id), cancellationToken);

        public Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<Product> Update(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductView>> GetAllProduct(CancellationToken cancellationToken)
            => await this.ExecuteQueryForOtherEntities<ProductView>(SCHEMA, "usp_GetAllProduct", cancellationToken);

        public async Task<IListWithCount<ProductView>> GetProduct(ProductFilterRequest prodFilterRequest, CancellationToken cancellationToken)
        {

            var query = this._dbContext.Set<ProductView>().ProductViewFilterTrim(prodFilterRequest);
            if (!string.IsNullOrEmpty(prodFilterRequest.Search))
            {
                query = query.Where(x => x.Name.Contains(prodFilterRequest.Search));
            }
            // Add any more steps of filter if require
            var totalCount = await query.CountAsync().ConfigureAwait(false);


            if (!string.IsNullOrEmpty(prodFilterRequest.SortField) && !string.IsNullOrEmpty(prodFilterRequest.SortDirection))
            {
                query = query.ApplySorting<ProductView>(prodFilterRequest.SortField, prodFilterRequest.SortDirection); // SortDirection = "OrderBy" : "OrderByDescending"
                             //.ApplyPaging<ProductView>(prodFilterRequest.PageSize, prodFilterRequest.PageIndex);
            }
            query = query.ApplyPaging<ProductView>(prodFilterRequest.PageSize, prodFilterRequest.PageNumber);
            var productList = await query.ToListAsync(cancellationToken).ConfigureAwait(false);
            
            return new DefaultListWithCount<ProductView>() { Data = productList, TotalCount = totalCount };
        }

        public Task<IEnumerable<ProductView>> GetUserOnlineProducts(string userEmail, IEnumerable<int> productTypeId, CancellationToken cancellationToken)
        {
            // SP is ready but write this logic latter, rather using another method feel that will more efficient
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductView>> GetOnlineProductByUserEmail(string userEmail, CancellationToken cancellationToken)
        {
            // Online product is taking Ebooks and Subscribe item
            int ebookProductTypeId = (int)SS.StudentStore.Services.Core.Enums.ProductType.Ebook;
            int subsProductTypeId = (int)SS.StudentStore.Services.Core.Enums.ProductType.Subscribe;
           var sqlParams = new List<SqlParameter>
           {
               new SqlParameter("@userEmail", userEmail){SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input},
               new SqlParameter("@ebookProductTypeId", ebookProductTypeId){SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input},
               new SqlParameter("@subscribeProductTypeId", subsProductTypeId){SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input},
           };

            var strParams = "@userEmail, @ebookProductTypeId, @subscribeProductTypeId";

            return await this.ExecuteQueryForOtherEntities<ProductView>(SCHEMA, "usp_GetOnlineProductByUserEmail", strParams, sqlParams, cancellationToken);
        }
    }
}
