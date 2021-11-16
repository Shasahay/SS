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
    public class GetProductTypeMappingByProductIdQuery : IRequest<IEnumerable<ProductTypeMappingResponse>>
    {
        public long ProductId { get; set; }
    }

    public class GetProductTypeMappingByProductIdQueryHandler : IRequestHandler<GetProductTypeMappingByProductIdQuery, IEnumerable<ProductTypeMappingResponse>>
    {
        private readonly IProductService _service;
        public GetProductTypeMappingByProductIdQueryHandler(IProductService productService)
            => this._service = productService ?? throw new ArgumentNullException(nameof(productService));
        public async Task<IEnumerable<ProductTypeMappingResponse>> Handle(GetProductTypeMappingByProductIdQuery request, CancellationToken cancellationToken)
            => await this._service.GetProductTypeMapping(request.ProductId, cancellationToken);
    }
}
