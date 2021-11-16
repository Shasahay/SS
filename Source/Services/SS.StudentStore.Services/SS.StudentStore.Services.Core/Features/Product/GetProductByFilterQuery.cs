using MediatR;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using SS.StudentStore.Services.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Product
{
    public class GetProductByFilterQuery : IRequest<DefaulListResponse<ProductViewResponse>>
    {
        public ProductFilterRequest productFilterRequest { get; set; }
    }

    public class GetProductByFilterQueryHandler : IRequestHandler<GetProductByFilterQuery, DefaulListResponse<ProductViewResponse>>
    {
        private readonly IProductService _service;

        public GetProductByFilterQueryHandler(IProductService productService) => this._service = productService ?? throw new ArgumentNullException(nameof(productService));

        public async Task<DefaulListResponse<ProductViewResponse>> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
         => await this._service.GetProduct(request.productFilterRequest, cancellationToken);
    }

}
