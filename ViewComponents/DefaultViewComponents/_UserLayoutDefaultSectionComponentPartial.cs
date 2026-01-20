using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.DefaultViewComponents
{
    public class _UserLayoutDefaultSectionComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutDefaultSectionComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
