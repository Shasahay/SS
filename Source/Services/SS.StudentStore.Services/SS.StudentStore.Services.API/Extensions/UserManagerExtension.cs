using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Extensions
{
    public static class UserManagerExtension
    {
        //This will help to get the address associated with email instead of injecting appIdentityContext
        //public static async Task<UserView> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<UserView> input, ClaimsPrincipal user)
        //{
        //    var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        //    return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        //}

        public static async Task<UserView> FindByEmailFromClaimsPrinciple(this UserManager<UserView> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
