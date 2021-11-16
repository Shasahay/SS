using Microsoft.IdentityModel.Tokens;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Helper;
using SS.StudentStore.Services.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SS.StudentStore.Services.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfigurationHelper _configHelper;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfigurationHelper configHelper)
        {
            this._configHelper = configHelper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configHelper.GetToken("Key")));
        }

        public string CreateToken(UserView user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _configHelper.GetToken("Issuer")
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
