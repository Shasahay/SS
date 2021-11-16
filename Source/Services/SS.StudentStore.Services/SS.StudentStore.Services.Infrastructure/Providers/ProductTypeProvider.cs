using Microsoft.Data.SqlClient;
using SS.StudentStore.Services.Core.Constants;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Infrastructure.Providers
{
    public class ProductTypeProvider : BaseProvider<ProductType>, IProductTypeProvider
    {
        private const string SCHEMA = Constant.Schema_Core;
        public ProductTypeProvider(CoreDBContext dbContext) : base(dbContext) { }
        public async Task<IEnumerable<ProductType>> GetProductTypes(CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntities(SCHEMA, "usp_GetAllProductType", cancellationToken); // SP still needs to be written

        public async Task<IEnumerable<ProductType>> GetProductTypesByProductId(long productId, CancellationToken cancellationToken)
            => await this.ExecuteQueryForEntities(SCHEMA, "usp_GetProductTypeById", "@productId", new SqlParameter("@productId", productId), cancellationToken); // SP still needs to be written
    }
}
