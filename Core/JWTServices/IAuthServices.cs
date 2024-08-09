using Core.IdentityServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.JWTServices
{
    public interface IAuthServices
    {
        Task<string> GenerateJWTToken(AppUser user , UserManager<AppUser> userManager);
    }
}
