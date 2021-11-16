using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface IStagingProductService
    {
        Task<SProductResponse> AddorUpdate(StagingProductRequest sProduct, string userEmail, CancellationToken cancellationToken);
        Task<IEnumerable<SProductResponse>> GetProducts(string userEmail, CancellationToken cancellationToken);
        Task<SProductResponse> GetProduct(long productId, string userEmail, CancellationToken cancellationToken);
    }
}
