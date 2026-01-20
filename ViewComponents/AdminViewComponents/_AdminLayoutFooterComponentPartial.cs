using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutFooterComponentPartial(TechnologyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var list = _context.Footers.ToList();
            return View(list);
        }
    }
}
