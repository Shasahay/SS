using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductViewResponse> Add(ProductRequest product, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ProductViewResponse>> GetAllProduct(CancellationToken cancellationToken); 
        Task<DefaulListResponse<ProductViewResponse>> GetProduct(ProductFilterRequest productFilterRequest, CancellationToken cancellationToken);
        Task<ProductViewResponse> GetProduct(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ProductViewResponse>> GetProducts(ProductFilterRequest productFilter, CancellationToken cancellationToken);
        Task<IEnumerable<ProductTypeResponse>> GetProductTypesByProductId(long productId, CancellationToken cancellationToken);
        Task<IEnumerable<ProductTypeMappingResponse>> GetProductTypeMapping (long productId, CancellationToken cancellationToken);
        Task<IEnumerable<ProductViewResponse>> GetOnlineProductByUserEmail(string userEmail, CancellationToken cancellationToken);
        Task<ProductViewResponse> Update(ProductRequest product, CancellationToken cancellationToken);
    }
}
