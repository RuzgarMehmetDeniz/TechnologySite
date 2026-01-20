using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.CategoryViewComponents
{
    public class _UserLayoutCategoryProductListComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutCategoryProductListComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryID == categoryId)
                .ToListAsync();

            return View(products);
        }
    }
}
