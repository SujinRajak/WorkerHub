using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
