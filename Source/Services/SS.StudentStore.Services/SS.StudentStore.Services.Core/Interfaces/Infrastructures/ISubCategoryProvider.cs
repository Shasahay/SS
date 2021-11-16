using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface ISubCategoryProvider
    {
        Task<IEnumerable<SubCategory>> GetSubCategories(CancellationToken cancellationToken);
    }
}
