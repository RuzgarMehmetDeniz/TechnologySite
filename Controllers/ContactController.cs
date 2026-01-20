using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;
using TechnologySite.Entities;

namespace TechnologySite.Controllers
{
    public class ContactController : Controller
    {
        private readonly TechnologyContext _context;

        public ContactController(TechnologyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {

            Contact newContact = new Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Description = contact.Description,
                Surname = contact.Surname
            };

            _context.Contacts.Add(newContact);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }
    }
}
