using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductProvider _productProvider;
        private readonly IProductTypeProvider _productTypeProvider;
        private readonly IProductTypeMappingProvider _ptMappingProvider;
        public ProductService(IMapper mapper, IProductProvider productProvider, IProductTypeProvider productTypeProvider, IProductTypeMappingProvider ptMappingProvider) : base(mapper)
        {
            this._productProvider = productProvider;
            this._productTypeProvider = productTypeProvider;
            this._ptMappingProvider = ptMappingProvider;
        }
        public Task<ProductViewResponse> Add(ProductRequest product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductViewResponse>> GetAllProduct(CancellationToken cancellationToken)
        {
            var result = await _productProvider.GetAllProduct(cancellationToken);
            return this._mapper.Map<IEnumerable<ProductView>, IEnumerable<ProductViewResponse>>(result);
        }
        public async Task<DefaulListResponse<ProductViewResponse>> GetProduct(ProductFilterRequest productFilterRequest, CancellationToken cancellationToken)
        {
            var result = await _productProvider.GetProduct(productFilterRequest, cancellationToken);
            return this._mapper.Map<IListWithCount<ProductView>, DefaulListResponse<ProductViewResponse>>(result);
        }
        public async Task<ProductViewResponse> GetProduct(int id, CancellationToken cancellationToken)
        {
            var result = await this._productProvider.GetProduct(id, cancellationToken);
            return this._mapper.Map<ProductView, ProductViewResponse>(result);
        }

        public Task<IEnumerable<ProductViewResponse>> GetProducts(ProductFilterRequest productFilter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductTypeMappingResponse>> GetProductTypeMapping(long productId, CancellationToken cancellationToken)
        {
            var ptMapping = await this._ptMappingProvider.GetProductTypeMappings(productId, cancellationToken);
            return this._mapper.Map<IEnumerable<ProductTypeMapping>, IEnumerable<ProductTypeMappingResponse>>(ptMapping);
        }

        public async Task<IEnumerable<ProductTypeResponse>> GetProductTypesByProductId(long productId, CancellationToken cancellationToken)
        {
            var productType = await this._productTypeProvider.GetProductTypesByProductId(productId, cancellationToken);
            var result = this._mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeResponse>>(productType);
            return (result);
        }

        public async Task<IEnumerable<ProductViewResponse>> GetOnlineProductByUserEmail(string userEmail, CancellationToken cancellationToken)
        {
            var product = await this._productProvider.GetOnlineProductByUserEmail(userEmail, cancellationToken);
            return this._mapper.Map<IEnumerable<ProductView>, IEnumerable<ProductViewResponse>>(product);
        }

        public Task<ProductViewResponse> Update(ProductRequest product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
       
    }
}
