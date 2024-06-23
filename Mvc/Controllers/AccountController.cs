using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Helper.Alert;
using Infrastructure.Identity;
using Infrastructure;
using ViewModel;
using Mvc.Helper;
using Mvc.Interfaces;
using Application.ViewModel;
using Application.Config;
using Microsoft.Extensions.Options;
using DevExpress.Utils.OAuth.Provider;
using Mvc.Models;

namespace Application.Controllers
{
    public class AccountController : AlertController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IApplicationUser _applicationinfo;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Appsettings _app;

        public AccountController(IOptions<Appsettings> appConfig, IHttpContextAccessor httpContextAccessor, IApplicationUser applicationinfo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _app = appConfig.Value;
            _httpContextAccessor = httpContextAccessor;
            _applicationinfo = applicationinfo;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(SignUpViewModel Input)
        {
            if (ModelState.IsValid)
            {
                //creating a new user object of my own and capturing data of the user from the model 
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                //to create new user we need to make use of the createasyn method to create a new user 
                //there are two overloaded version so the first instance is of the user oof type my own User object
                //the second param is the password.so then this password is then hash stored securely oin the database
                //create aync is an asynchornous methos so we should await it and since it is the await we need to turn into async method
                // and wrap the action result in a task
                string password = RandomPassGenerator.GeneratePassword(12, includeUppercase: true, includeLowercase: true, includeDigits: true, includeSpecialCharacters: true);

                var result = await _userManager.CreateAsync(user, password);

                //built in method suceeeded to check if the result succeded or not
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmlink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = token }, Request.Scheme);
                    var request = _httpContextAccessor.HttpContext.Request;
                    var baseUrl = $"{request.Scheme}://{request.Host}";

                    EmailConfirmationModel emailConfirmationModel = new EmailConfirmationModel()
                    {
                        EmailConfirmationLink = confirmlink,
                        UserName = user.UserName,
                        Password = password,
                    };
                    _applicationinfo.SendEmail(emailConfirmationModel, _app.EmailTemplatePath);
                    //sign in th user and forwarded to the location
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    Success("Email Has been sent to the user for Email Verification", true);
                    return RedirectToAction("Login", "Account");
                }

                Danger("Error Occured while Sending Email to the User!", true);
                //loopthrough each errors in error collection
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(Input);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                Danger($"Sorry, the token and userId is invalid!", true);
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                Danger($"This User Id {userId} i not valid", true);
                return View("NotFound");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                Success("Email Has been verified, Please proceed with login!", true);
                return RedirectToAction("Login", "Account");
            }
            Danger("Email cannot be Confirmed", true);
            return View("Error");
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //int? v = User;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginRequestViewModel model)
        {
            if (ModelState.IsValid)
            {

                var users = await _userManager.FindByEmailAsync(model.Username);
                if (users != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(users))
                    {
                        ModelState.AddModelError("", "You must have a confirmed email to log on.");
                        return View();
                    }
                }
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);
                //built in method suceeeded to check if the result succeded or not
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Username);
                    // Get the roles for the user
                    var roles = await _userManager.GetRolesAsync(user);
                    Success("User Logged in!", true);
                    if (roles.First() == "Admin")
                    {
                        return RedirectToAction("AdminPage", "Administration");
                    }
                    else if (roles.First() == "Hiring Manager")
                    {
                        return RedirectToAction("HighHome", "High");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                Danger("Invalid User Login!", true);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
