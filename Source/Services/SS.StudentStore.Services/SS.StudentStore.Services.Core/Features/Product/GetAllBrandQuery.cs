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
    public class GetAllBrandQuery : IRequest<IEnumerable<BrandResponse>>
    {

    }

    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<BrandResponse>>
    {
        private readonly IBrandService _brandService;
        public GetAllBrandQueryHandler(IBrandService brandService)
            => this._brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));

        public async Task<IEnumerable<BrandResponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
            => await this._brandService.GetBrands(cancellationToken);
    }
}
