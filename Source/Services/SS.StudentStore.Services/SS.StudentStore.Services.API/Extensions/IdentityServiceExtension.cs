using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SS.StudentStore.Services.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SS.StudentStore.Services.Infrastructure.DBContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SS.StudentStore.Services.API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<UserView>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            //builder.AddEntityFrameworkStores<AppIdentityDBContext>();
            builder.AddSignInManager<SignInManager<UserView>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                            ValidIssuer = configuration["Token:Issuer"],
                            ValidateIssuer = true,
                            ValidateAudience = false
                        };
                    });
            return services;
        }
    }
}
