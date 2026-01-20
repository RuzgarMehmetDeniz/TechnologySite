using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.CartViewComponent
{
    public class _UserLayoutCartComponentPartial:ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutCartComponentPartial(TechnologyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
