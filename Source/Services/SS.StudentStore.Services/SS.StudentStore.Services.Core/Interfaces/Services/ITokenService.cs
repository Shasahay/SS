using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface ITokenService
    {
       string CreateToken(UserView user);
    }
}
