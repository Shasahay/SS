using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IProductTypeMappingProvider
    {
        Task<IEnumerable<ProductTypeMapping>> GetProductTypeMappings(long productId, CancellationToken cancellationToken);
    }
}
