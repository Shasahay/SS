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
    public class GradeService : BaseService, IGradeService
    {
        private readonly IGradeProvider _gradeProvider;
        public GradeService(IMapper mapper, IGradeProvider gradeProvider) : base(mapper)
        {
            this._gradeProvider = gradeProvider;
        }
        public async Task<IEnumerable<GradeResponse>> GetGrades(CancellationToken cancellationToken)
        {
            var result = await _gradeProvider.GetGrades(cancellationToken);
            return this._mapper.Map<IEnumerable<Grade>, IEnumerable<GradeResponse>>(result);
        }
    }
}
