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
    public class StagingProductService : BaseService, IStagingProductService
    {
        private readonly IStagingProductProvider _prodProvider;
        public StagingProductService(IMapper mapper, IStagingProductProvider stagingProductProvider) : base(mapper)
        {
            this._prodProvider = stagingProductProvider;
        }

        public async Task<SProductResponse> AddorUpdate(StagingProductRequest sProduct, string userEmail, CancellationToken cancellationToken)
        {
            var product = this._mapper.Map<StagingProductRequest, StagingProduct>(sProduct);
            var result = await this._prodProvider.AddOrUpdateProduct(product, userEmail, cancellationToken);
            return this._mapper.Map<StagingProductView, SProductResponse>(result)
;        }

        public async Task<SProductResponse> GetProduct(long productId, string userEmail, CancellationToken cancellationToken)
        {
            var product = await this._prodProvider.GetProduct(productId, userEmail, cancellationToken);
            return this._mapper.Map<StagingProductView, SProductResponse>(product);
        }

        public async Task<IEnumerable<SProductResponse>> GetProducts(string userEmail, CancellationToken cancellationToken)
        {
            var product = await this._prodProvider.GetAllProduct(userEmail, cancellationToken);
            return this._mapper.Map<IEnumerable<StagingProductView>, IEnumerable<SProductResponse>>(product);
        }
    }
}
