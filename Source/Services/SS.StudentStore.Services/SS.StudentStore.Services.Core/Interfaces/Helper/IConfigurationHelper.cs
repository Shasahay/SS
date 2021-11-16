using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Interfaces.Helper
{
    public interface IConfigurationHelper
    {
        string GetToken(string key);
    }
}
