using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Product
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<CategoryResponse>>
    {

    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoryQueryHandler(ICategoryService categoryService) => this._categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            => await this._categoryService.GetCategories(cancellationToken);
    }
}
