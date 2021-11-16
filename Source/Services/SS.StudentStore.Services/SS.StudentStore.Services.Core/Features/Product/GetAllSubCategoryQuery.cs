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
    public class GetAllSubCategoryQuery : IRequest<IEnumerable<SubCategoryResponse>>
    {
    }

    public class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQuery, IEnumerable<SubCategoryResponse>>
    {
        private readonly ISubCategoryService _subCategoryService;
        public GetAllSubCategoryQueryHandler(ISubCategoryService subCategoryService)
            => this._subCategoryService = subCategoryService ?? throw new ArgumentNullException(nameof(subCategoryService));
        public async Task<IEnumerable<SubCategoryResponse>> Handle(GetAllSubCategoryQuery request, CancellationToken cancellationToken)
            => await this._subCategoryService.GetSubCategories(cancellationToken);
    }
}
