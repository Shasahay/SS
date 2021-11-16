using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;

        protected BaseService(IMapper mapper)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
