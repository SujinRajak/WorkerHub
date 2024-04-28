using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Helper.Alert;
using Infrastructure.Identity;
using Infrastructure;

namespace Application.Controllers
{
    public class AccountController : AlertController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        //private readonly IApplicationUser _applicationinfo;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController()
        {
        }



        /// <summary>
        /// Register
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Register()
        //{
        //    RegisterViewModel register = new RegisterViewModel();
        //    register.Roles = roleManager.Roles.Where(x => x.Name != "Admin").ToList();
        //    return View(register);
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register(RegisterViewModel Input)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //creating a new user object of my own and capturing data of the user from the model 
        //        var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, Firstname = Input.FirstName, LastName = Input.LastName, InactiveUsers = false, dob = DateTime.Now, Availablility = true };
        //        //to create new user we need to make use of the createasyn method to create a new user 
        //        //there are two overloaded version so the first instance is of the user oof type my own User object
        //        //the second param is the password.so then this password is then hash stored securely oin the database
        //        //create aync is an asynchornous methos so we should await it and since it is the await we need to turn into async method
        //        // and wrap the action result in a task
        //        var result = await _userManager.CreateAsync(user, Input.Password);
        //        var role = await roleManager.FindByIdAsync(Input.RoleName);
        //        if (role == null)
        //        {
        //            ViewBag.ErrorMessage = $"Role with Role id ={Input.RoleName} count not be found";
        //            return View();

        //        }
        //        var userRoleresult = await _userManager.AddToRoleAsync(user, role.Name);
        //        if (Input.RoleName == null)
        //        {
        //            ModelState.AddModelError("", "You must have a confirmed email to log on.");


        //            Input.Roles = roleManager.Roles.Where(x => x.Name != "Admin").ToList();
        //            return View();
        //        }


        //        //built in method suceeeded to check if the result succeded or not
        //        if (result.Succeeded && userRoleresult.Succeeded)
        //        {
        //            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            var confirmlink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = token }, Request.Scheme);
        //            var message = new MimeMessage();
        //            message.From.Add(new MailboxAddress("Confirm Your Email", "rajaksujin.sr@gmail.com"));
        //            message.To.Add(new MailboxAddress(user.Firstname, user.UserName));
        //            message.Subject = "Email Confirmation";
        //            var bodyBuilder = new BodyBuilder();
        //            bodyBuilder.HtmlBody = "<b>" + confirmlink + "</b>";
        //            bodyBuilder.TextBody = "This is some plain text";

        //            message.Body = bodyBuilder.ToMessageBody();
        //            using (var client = new SmtpClient())
        //            {
        //                client.Connect("smtp.gmail.com", 587, false);
        //                client.Authenticate("rajaksujin.sr@gmail.com", "$Uj##N$p123");
        //                client.Send(message);
        //                client.Disconnect(true);
        //            }
        //            //sign in th user and forwarded to the location
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            //var abc = System.Security.Claims.ClaimsPrincipal.Current.Identities.ToList();

        //            //sending the value of the user id from controller to the views
        //            //return RedirectToAction("CreateRole", "Administration");
        //            return RedirectToAction("Login", "Account");
        //        }

        //        //loopthrough each errors in error collection
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }
        //    return View(Input);
        //}





        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
    }
}
