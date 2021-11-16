using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Services
{
    public class BrandService : BaseService, IBrandService
    {
        private readonly IBrandProvider _brandProvider;

        public BrandService(IMapper mapper, IBrandProvider brandProvider) : base(mapper)
        {
            this._brandProvider = brandProvider;
        }
        public async Task<IEnumerable<BrandResponse>> GetBrands(CancellationToken cancellationToken)
        {
            var result = await _brandProvider.GetBrands(cancellationToken);
            return this._mapper.Map<IEnumerable<Brand>, IEnumerable<BrandResponse>>(result);
        }
    }
}
