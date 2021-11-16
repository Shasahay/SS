using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Models.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IProductProvider
    {
        Task<Product> Add(Product product, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken);
        Task<IEnumerable<ProductView>> GetAllProduct(CancellationToken cancellationToken);
        Task<IListWithCount<ProductView>> GetProduct(ProductFilterRequest productFilterRequest, CancellationToken cancellationToken);
        Task<ProductView> GetProduct(long id, CancellationToken cancellationToken);
        Task<IEnumerable<ProductView>> GetUserOnlineProducts(string userEmail, IEnumerable<int> productTypeId, CancellationToken cancellationToken);
        Task<IEnumerable<ProductView>> GetOnlineProductByUserEmail(string userEmail, CancellationToken cancellationToken);
        Task<Product> Update(Product product, CancellationToken cancellationToken);
        
    }
}
