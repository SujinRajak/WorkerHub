using Mvc.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class AdminController : Controller
    {
        private IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;     
        }

        [HttpGet]
        public async Task<IActionResult> AdminPage()
        {
            var role = roleManager.Roles.ToList();
            var highmang = (from c in _context.UserRoles
                            join p in _context.Roles on c.RoleId equals p.Id
                            where p.Name != "Employee" && p.Name != "Admin"
                            select new { c.UserId }).ToList();
            var Employee = (from c in _context.UserRoles
                            join p in _context.Roles on c.RoleId equals p.Id
                            where p.Name != "Hiring Manager" && p.Name != "Admin"
                            select new { c.UserId }).ToList();
            AdminProfileModel model = new AdminProfileModel()
            {
                identityRoles = role,
                AppUser = _context.applicationUser.ToList(),
                HighUserRole = highmang.Select(x => x.UserId).ToList(),
                EmployeeUserRole = Employee.Select(x => x.UserId).ToList(),
                UserRole = _context.UserRoles.ToList(),
                Roles = roleManager.Roles.ToList()
            };

            foreach (var item in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(item, role.Select(a => a.Name).ToString()))
                {
                    model.Users.Add(item.UserName);
                }
            }
            return View(model);
        }
       
    }
}
