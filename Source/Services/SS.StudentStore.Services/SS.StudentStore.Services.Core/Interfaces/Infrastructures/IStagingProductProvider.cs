using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IStagingProductProvider
    {
        Task<IEnumerable<StagingProductView>> GetAllProduct(string UserEmail, CancellationToken cancellationToken);
        Task<StagingProductView> GetProduct(long productId, string userEmail, CancellationToken cancellationToken);
        Task<StagingProductView> AddOrUpdateProduct(StagingProduct sProduct, string userEmail, CancellationToken cancellationToken);
    }
}
