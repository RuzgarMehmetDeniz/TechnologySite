using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

namespace TechnologySite.Controllers
{
    public class AboutController : Controller
    {
        private readonly TechnologyContext _context;

        public AboutController(TechnologyContext context)
        {
            _context = context;
        }

        public IActionResult AboutPage()
        {
            var about=_context.Abouts.Take(1).ToList();
            return View(about);
        }

    }
}
