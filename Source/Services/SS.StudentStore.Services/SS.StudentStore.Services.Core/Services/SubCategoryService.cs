using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Services
{
    public class SubCategoryService : BaseService, ISubCategoryService
    {
        private readonly ISubCategoryProvider _subCategoryProvider;
        public SubCategoryService(IMapper mapper, ISubCategoryProvider subCategoryProvider) : base(mapper)
        {
            this._subCategoryProvider = subCategoryProvider;
        }
        public async Task<IEnumerable<SubCategoryResponse>> GetSubCategories(CancellationToken cancellationToken)
        {
            var result = await this._subCategoryProvider.GetSubCategories(cancellationToken);
            return this._mapper.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryResponse>>(result);
        }
    }
}
