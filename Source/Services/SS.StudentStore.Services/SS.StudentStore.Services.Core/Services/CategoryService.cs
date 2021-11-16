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
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryProvider _categoryProvider;
        public CategoryService(IMapper mapper, ICategoryProvider categoryProvider) : base(mapper)
        {
            this._categoryProvider = categoryProvider;
        }
        public async Task<IEnumerable<CategoryResponse>> GetCategories(CancellationToken cancellationToken)
        {
            var result = await _categoryProvider.GetCategories(cancellationToken);
            return this._mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResponse>>(result);
        }
    }
}
