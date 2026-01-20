using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutCategoryListComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutCategoryListComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }
    }
}
