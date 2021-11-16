using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using SS.StudentStore.Services.Core.Models.Response;
using System.Threading.Tasks;
using System.Threading;
using SS.StudentStore.Services.Core.Interfaces.Services;

namespace SS.StudentStore.Services.Core.Features.Product
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductViewResponse>>
    {
    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductViewResponse>>
    {
        private readonly IProductService _service;
        public GetAllProductQueryHandler(IProductService service) => this._service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task<IEnumerable<ProductViewResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        => await this._service.GetAllProduct(cancellationToken);
    }
}
