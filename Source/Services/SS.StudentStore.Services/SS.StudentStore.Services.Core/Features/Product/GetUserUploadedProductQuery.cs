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
    public class GetUserUploadedProductQuery : IRequest<IEnumerable<SProductResponse>>
    {
        public string UserName { get; set; }
    }

    public class GetUserUploadedProductQueryHandler : IRequestHandler<GetUserUploadedProductQuery, IEnumerable<SProductResponse>>
    {
        private readonly IStagingProductService _spService;

        public GetUserUploadedProductQueryHandler(IStagingProductService stagingProductService)
            => this._spService = stagingProductService ?? throw new ArgumentNullException(nameof(stagingProductService));

        public async Task<IEnumerable<SProductResponse>> Handle(GetUserUploadedProductQuery request, CancellationToken cancellationToken)
            => await this._spService.GetProducts(request.UserName, cancellationToken);
    }
}
