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
    public class GetProductByIdQuery : IRequest<ProductViewResponse>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewResponse>
    {
        private readonly IProductService _service;

        public GetProductByIdQueryHandler(IProductService productService)
            => this._service = productService ?? throw new ArgumentNullException(nameof(productService));
        public async Task<ProductViewResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            => await this._service.GetProduct(request.Id, cancellationToken);
    }

}
