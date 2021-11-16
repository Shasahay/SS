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
    public class SectionService : BaseService, ISectionService
    {
        private readonly ISectionProvider _sectionProvider;

        public SectionService(IMapper mapper, ISectionProvider sectionProvider) : base(mapper)
        {
            this._sectionProvider = sectionProvider;
        }
        public async Task<IEnumerable<SectionResponse>> GetSections(CancellationToken cancellationToken)
        {
            var result = await this._sectionProvider.GetSections(cancellationToken);
            return this._mapper.Map<IEnumerable<Section>, IEnumerable<SectionResponse>>(result);
        }
    }
}
