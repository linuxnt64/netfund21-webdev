using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {     
        private readonly SqlContext _context;

        public ContactsController(SqlContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            ViewData["Title"] = "Kontakta Oss";
            ViewData["ControllerName"] = "Contacts";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactForm model)
        {
            ViewData["Title"] = "Kontakta Oss";
            ViewData["ControllerName"] = "Contacts";

            if (ModelState.IsValid)
            {
                _context.ContactRequests.Add(new ContactFormEntity(model.Name, model.Email, model.Message));
                await _context.SaveChangesAsync();
                
                return RedirectToAction("ContactConfirm");
            }

            return View(model);
        }

        public IActionResult ContactConfirm()
        {
            ViewData["Title"] = "Tack för din förfrågan";
            ViewData["ControllerName"] = "Contacts";

            return View();
        }

    }
}
