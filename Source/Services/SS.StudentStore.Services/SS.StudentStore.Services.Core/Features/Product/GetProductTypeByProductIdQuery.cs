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
    public class GetProductTypeByProductIdQuery : IRequest<IEnumerable<ProductTypeResponse>>
    {
        public long ProductId { get; set; }
    }

    public class GetProductTypeByProductIdQueryHandler : IRequestHandler<GetProductTypeByProductIdQuery, IEnumerable<ProductTypeResponse>>
    {
        private readonly IProductService _service;

        public GetProductTypeByProductIdQueryHandler(IProductService productService)
            => this._service = productService ?? throw new ArgumentNullException(nameof(productService));
        public async Task<IEnumerable<ProductTypeResponse>> Handle(GetProductTypeByProductIdQuery request, CancellationToken cancellationToken)
            => await this._service.GetProductTypesByProductId(request.ProductId, cancellationToken);
    }
}
