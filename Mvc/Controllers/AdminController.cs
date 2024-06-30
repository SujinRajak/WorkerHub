using Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Mvc.Controllers
{
    public class AdminController : Controller
    {
        private IAdmin _admin;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(IAdmin admin, RoleManager<IdentityRole> roleManager)
        {
            _admin = admin;  
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            DateTime timeOfDayGreeting = DateTime.Now;
            var greeting = "";
            if (timeOfDayGreeting.Hour >= 5 && timeOfDayGreeting.Hour < 12)
            {
                greeting = "Good Morning";
            }
            else if (timeOfDayGreeting.Hour >= 12 && timeOfDayGreeting.Hour < 16)
            {
                greeting = "Good Afternoon";
            }
            else
            {
                greeting = "Good Evening";
            }

            var loggedInUserName = User.Claims.FirstOrDefault(a => a.Type == "EmployeeName");
            ViewData["HeaderText"] = $"{greeting} - {loggedInUserName?.Value}";
            var dashboardCount = _admin.GetTotalCount();
            return View(dashboardCount);
        }

        [HttpGet("GetAllEmployeeInfo")]
        public async Task<object> GetAllEmployeeInfo(DataSourceLoadOptions loadOptions)
        {
            var data = await _admin.GetAllEmployeeInfo();
            if (data.Count > 0)
            {
                return DataSourceLoader.Load(data.OrderBy(a => a.Name), loadOptions);
            }
            return DataSourceLoader.Load(new List<vw_EmployeeInfo>(), loadOptions);
        }


        [HttpGet("GetAllEmployeeList")]
        public async Task<object> GetAllEmployeeList(DataSourceLoadOptions loadOptions)
        {
            var data = await _admin.GetAllEmployees();
            if (data.Count > 0)
            {
                return DataSourceLoader.Load(data.OrderBy(a => a.Name), loadOptions);
            }
            return DataSourceLoader.Load(new List<vw_EmployeeList>(), loadOptions);
        }

        [HttpGet("GetAllHigeringManagersList")]
        public async Task<object> GetAllHigeringManagersList(DataSourceLoadOptions loadOptions)
        {
            var data = await _admin.GetAllHiringManagersList();
            if (data.Count > 0)
            {
                return DataSourceLoader.Load(data.OrderBy(a=>a.Name), loadOptions);
            }
            return DataSourceLoader.Load(new List<vw_HiringMangersList>(), loadOptions);
        }

        [HttpGet("GetAllRoles")]
        public async Task<object> GetAllRoles(DataSourceLoadOptions loadOptions)
        {
            var data = await _roleManager.Roles.ToListAsync();

            if (data !=null)
            {
                return DataSourceLoader.Load(data, loadOptions);
            }
            return DataSourceLoader.Load(new List<vw_HiringMangersList>(), loadOptions);
        }


        [HttpGet("GetAdditionalContent")]
        public IActionResult GetAdditionalContent(string type)
        {
            if (type == "users")
            {
                // Return the partial view for users
                return PartialView("_UserGridPartial");
            }
            else if (type == "hiring-managers")
            {
                return PartialView("_HiringMangersGridPartial");
            }
            else if ( type == "employees")
            {
                return PartialView("_EmployeeInfo");
            } 
            else if ( type == "roles")
            {
                return PartialView("_RolesInfo");
            }
            
            string content = type switch
            {
                _ => "No content available."
            };

            return Content(content);
        }


        [HttpGet("UserRole")]
        public IActionResult UserRole(DataSourceLoadOptions loadOptions)
        {
            return View();
        }

        [HttpGet("GetAllUserRoles")]
        public async Task<object> GetUserRole(DataSourceLoadOptions loadOptions)
        {
            var data = await _admin.GetAllUserRoles();
            if (data != null)
            {
                return DataSourceLoader.Load(data.OrderBy(a => a.Name), loadOptions);
            }
            return DataSourceLoader.Load(new List<vw_UserRoles>(), loadOptions);
            
        }


        //[HttpGet]
        //public async Task<IActionResult> AdminPage()
        //{
        //    var role = roleManager.Roles.ToList();
        //    var highmang = (from c in _context.UserRoles
        //                    join p in _context.Roles on c.RoleId equals p.Id
        //                    where p.Name != "Employee" && p.Name != "Admin"
        //                    select new { c.UserId }).ToList();
        //    var Employee = (from c in _context.UserRoles
        //                    join p in _context.Roles on c.RoleId equals p.Id
        //                    where p.Name != "Hiring Manager" && p.Name != "Admin"
        //                    select new { c.UserId }).ToList();
        //    AdminProfileModel model = new AdminProfileModel()
        //    {
        //        identityRoles = role,
        //        AppUser = _context.applicationUser.ToList(),
        //        HighUserRole = highmang.Select(x => x.UserId).ToList(),
        //        EmployeeUserRole = Employee.Select(x => x.UserId).ToList(),
        //        UserRole = _context.UserRoles.ToList(),
        //        Roles = roleManager.Roles.ToList()
        //    };

        //    foreach (var item in _userManager.Users)
        //    {
        //        if (await _userManager.IsInRoleAsync(item, role.Select(a => a.Name).ToString()))
        //        {
        //            model.Users.Add(item.UserName);
        //        }
        //    }
        //    return View(model);
        //}

    }
}
