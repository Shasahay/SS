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
    public class GetUserOnlineProductsByEmailQuery : IRequest<IEnumerable<ProductViewResponse>>
    {
        public string UserEmail { get; set; }
    }

    public class GetUserOnlineProductsByEmailQueryHandle : IRequestHandler<GetUserOnlineProductsByEmailQuery, IEnumerable<ProductViewResponse>>
    {
        private readonly IProductService _productService;
        public GetUserOnlineProductsByEmailQueryHandle(IProductService productService)
            => this._productService = productService ?? throw new ArgumentNullException(nameof(productService));
        public async Task<IEnumerable<ProductViewResponse>> Handle(GetUserOnlineProductsByEmailQuery request, CancellationToken cancellationToken)
            => await this._productService.GetOnlineProductByUserEmail(request.UserEmail, cancellationToken);
    }
}
