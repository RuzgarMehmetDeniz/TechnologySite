using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutContentRowComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutContentRowComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Categories.Count();
            ViewBag.v2 = _context.Products.Count();
            ViewBag.v3 = _context.Teams.Count();
            ViewBag.v4 = _context.Contacts.Count();
            return View();
        }
    }
}
