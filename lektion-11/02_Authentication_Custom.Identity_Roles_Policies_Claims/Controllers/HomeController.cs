using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }






        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize(Roles = "admin,usermanager")]
        public IActionResult UserCenter()
        {
            return View();
        }


        [Authorize(Policy = "Admins")]
        public IActionResult AdminCenter()
        {
            return View();
        }













        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}