using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Helper
{
    public static class UserPrincipalExtension
    {

        public static string GetUserClaim(this ClaimsPrincipal user, string claimType)
        {
            if (user.Identity.IsAuthenticated)
            {
                var claim = user.Claims.FirstOrDefault(v => v.Type == claimType);
                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return "";
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            var userRole = user.GetUserClaim("Role");
            return userRole.Contains("Admin");
        }

        public static bool IsHighringManager(this ClaimsPrincipal user)
        {
            var userRole = user.GetUserClaim("Role");
            return userRole.Contains("Hiring Manager");
        }

        public static bool IsEmployee(this ClaimsPrincipal user)
        {
            var userRole = user.GetUserClaim("Role");
            return userRole.Contains("Employee");
        }
    }
}
