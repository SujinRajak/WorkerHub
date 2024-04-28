using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class ClaimPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        ApplicationDbContext _db;

        public ClaimPrincipalFactory(
        UserManager<ApplicationUser> userManager,
        //RoleManager<ApplicationUser> roleManager,
        IOptions<IdentityOptions> optionsAccessor, ApplicationDbContext db) : base(userManager, optionsAccessor)
        {
            _db = db;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

           // var appUser = await _db.vw_EmployeeInfo.FirstOrDefaultAsync(c => c.UserName == user.UserName) ?? new vw_EmployeeInfo();

           // ((ClaimsIdentity)principal.Identity).AddClaims(new[] {

           //// new Claim("EmployeeName",appUser.FullName?? ""),
           // //new Claim("UserType",appUser.emp_type??""),
           // //new Claim("UserId", appUser.UserId ?? ""),
           //// new Claim("Role", appUser.Role?? ""),
           //// new Claim("EmployeeId", appUser.EmployeeId.ToString())

           // });

            return principal;
        }

    }
}
