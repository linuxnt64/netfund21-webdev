// POST: https://domain.com/auth/register
// POST: https://domain.com/register      [Route("register")]


using _01_Autentication_IndividualAccounts.Data;
using _01_Autentication_IndividualAccounts.Models.Forms;
using _01_Autentication_IndividualAccounts.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_Autentication_IndividualAccounts.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProfileManager _profileManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IProfileManager profileManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _profileManager = profileManager;
        }






        #region Register


        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            var form = new RegisterForm();
            return View(form);
        }

        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterForm form)
        {
            if(ModelState.IsValid)
            {
                if(!await _roleManager.Roles.AnyAsync())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }

                if(!await _userManager.Users.AnyAsync())
                {
                    form.RoleName = "admin";
                }

                if(await _userManager.Users.AnyAsync(x => x.Email == form.Email))
                {
                    ViewData["ErrorMessage"] = "Det finns redan en användare med samma e-postadress.";
                    return View(form);
                }

                var user = new IdentityUser { UserName = form.Email, Email = form.Email };
                var result = await _userManager.CreateAsync(user, form.Password);
                
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, form.RoleName);

                    var userProfile = new UserProfile
                    {
                        UserId = user.Id,
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        StreetName = form.StreetName,
                        PostalCode = form.PostalCode,
                        City = form.City
                    };
                    await _profileManager.CreateAsync(userProfile);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }


        #endregion

        #region Login

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            var form = new LoginForm();
            return View(form);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, isPersistent: false, false);
                if (result.Succeeded)
                {
                   return RedirectToAction("Index", "Home");
                }
            }

            ViewData["ErrorMessage"] = "Felaktig e-postadress eller lösenord";
            return View(form);
        }

        #endregion

        #region Logout

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
