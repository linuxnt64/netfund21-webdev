using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Tjänster";
            ViewData["ControllerName"] = "Services";

            return View();
        }
    }
}
