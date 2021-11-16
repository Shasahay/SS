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
    public class SubCategoryProvider : BaseProvider<SubCategory>, ISubCategoryProvider
    {
        private const string SCHEMA = Constant.Schema_Core;
        public SubCategoryProvider(CoreDBContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<SubCategory>> GetSubCategories(CancellationToken cancellationToken)
        => await this.ExecuteQueryForEntities(SCHEMA, "usp_GetAllSubCategory", cancellationToken);
    }
}
