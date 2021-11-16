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
    public class GetAllSectionQuery : IRequest<IEnumerable<SectionResponse>>
    {

    }

    public class GetAllSectionQueryHandler : IRequestHandler<GetAllSectionQuery, IEnumerable<SectionResponse>>
    {
        private readonly ISectionService _sectionService;
        public GetAllSectionQueryHandler(ISectionService sectionService)
            => this._sectionService = sectionService ?? throw new ArgumentNullException(nameof(sectionService));
        public Task<IEnumerable<SectionResponse>> Handle(GetAllSectionQuery request, CancellationToken cancellationToken)
            => this._sectionService.GetSections(cancellationToken);
    }
}
