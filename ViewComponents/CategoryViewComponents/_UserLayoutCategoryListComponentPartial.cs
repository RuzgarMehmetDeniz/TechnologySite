using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.CategoryViewComponents
{
    public class _UserLayoutCategoryListComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutCategoryListComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            return View(categories);
        }
    }
}
