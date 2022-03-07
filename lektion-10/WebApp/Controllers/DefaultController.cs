using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        private readonly SqlContext _context;

        public DefaultController(SqlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Välkommen";
            ViewData["ControllerName"] = "Default";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactForm model)
        {
            ViewData["Title"] = "Välkommen";
            ViewData["ControllerName"] = "Default";

            if (ModelState.IsValid)
            {
                _context.ContactRequests.Add(new ContactFormEntity(model.Name, model.Email, model.Message));
                await _context.SaveChangesAsync();

                return RedirectToAction("ContactConfirm", "Contacts");
            }

            return View(model);
        }

    }
}
