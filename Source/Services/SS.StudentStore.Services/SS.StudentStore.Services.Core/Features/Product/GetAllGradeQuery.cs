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
    public class GetAllGradeQuery : IRequest<IEnumerable<GradeResponse>>
    {

    }

    public class GetAllGradeQueryHandler : IRequestHandler<GetAllGradeQuery, IEnumerable<GradeResponse>>
    {
        private readonly IGradeService _gradeService;
        public GetAllGradeQueryHandler(IGradeService gradeService)
            => this._gradeService = gradeService ?? throw new ArgumentNullException(nameof(gradeService));

        public async Task<IEnumerable<GradeResponse>> Handle(GetAllGradeQuery request, CancellationToken cancellationToken)
            => await this._gradeService.GetGrades(cancellationToken);
    }
    
}
