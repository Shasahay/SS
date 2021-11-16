using Microsoft.Extensions.Configuration;
using SS.StudentStore.Services.Core.Interfaces.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.Helper
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private readonly IConfiguration _configuration;
        public ConfigurationHelper(IConfiguration configuration)
            => this._configuration = configuration;
        public string GetToken(string key)
            => this._configuration.GetSection("Token").GetValue<string>(key);
    }
}
