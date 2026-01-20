using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutTopSliderComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutTopSliderComponentPartial(TechnologyContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.TopSliders.ToList();
            return View(values);
        }
    }
}
