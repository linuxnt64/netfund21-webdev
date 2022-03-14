using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data;
using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Models;
using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Controllers
{
    public class AuthController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAddressManager _addressManager;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IAddressManager addressManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _addressManager = addressManager;
        }



        #region SignUp


        [HttpGet]
        public IActionResult SignUp(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new SignUpForm();
            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            if(ModelState.IsValid)
            {
                if(!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("user"));
                }

                if (!_userManager.Users.Any())
                    form.RoleName = "admin";



                var user = new ApplicationUser()
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    UserName = form.Email
                };

                var result = await _userManager.CreateAsync(user, form.Password);
                if(result.Succeeded)
                {
                    var address = new ApplicationAddress()
                    {
                        StreetName = form.StreetName,
                        PostalCode = form.PostalCode,
                        City = form.City
                    };

                    try { await _addressManager.CreateUserAddressAsync(user, address); }
                    catch { }

                    try { await _userManager.AddToRoleAsync(user, form.RoleName); }
                    catch { }
                    
                    try { await _signInManager.SignInAsync(user, isPersistent: false); }
                    catch { }


                    if (form.ReturnUrl == null || form.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(form.ReturnUrl);
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

            }

            return View();
        }


        #endregion

        #region SignIn

        [HttpGet]
        public IActionResult SignIn(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new SignInForm();
            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, isPersistent: false, false);
                if(result.Succeeded)
                {
                    if (form.ReturnUrl == null || form.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(form.ReturnUrl);
                }
            }

            ViewData["Error"] = "Felaktig e-postadress eller lösenord";
            form.Password = "";

            return View(form);
        }

        #endregion

        #region SignOut

        public async Task<IActionResult> SignOut()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }



        #endregion


        #region Access Denied

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}
