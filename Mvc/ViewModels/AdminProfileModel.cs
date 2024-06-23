using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Mvc.ViewModels
{
    public class AdminProfileModel
    {
        public IEnumerable<IdentityRole> identityRoles { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<IdentityUserRole<string>> UserRole { get; set; }
        public List<ApplicationUser> AppUser { get; set; }
        public List<string> HighUserRole { get; set; } = new List<string>();
        public List<string> EmployeeUserRole { get; set; }
        public List<string> Users { get; set; }
    }
}
