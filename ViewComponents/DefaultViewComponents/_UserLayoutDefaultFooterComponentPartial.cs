using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Models;

namespace TechnologySite.ViewComponents.DefaultViewComponents
{
    public class _UserLayoutDefaultFooterComponentPartial:ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutDefaultFooterComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public  IViewComponentResult Invoke()
        {
            var model = new FooterViewModel
            {
                Footers = _context.Footers.ToList(),
                Categories = _context.Categories.Take(10).ToList()
            };

            return View(model);
        }
    }
}
