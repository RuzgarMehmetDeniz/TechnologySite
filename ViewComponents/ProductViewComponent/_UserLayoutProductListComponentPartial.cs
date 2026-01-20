using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;
using TechnologySite.ViewModels;

namespace TechnologySite.ViewComponents.ProductViewComponent
{
    public class _UserLayoutProductListComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutProductListComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(ShopViewModel model)
        {
            if (model == null)
            {
                var categories = await _context.Categories.ToListAsync();
                model = new ShopViewModel
                {
                    Categories = categories,
                    Products = new List<Product>(),
                    SelectedCategoryId = null
                };
            }
            else if (model.SelectedCategoryId != null)
            {
                model.Products = await _context.Products
                    .Where(p => p.CategoryID == model.SelectedCategoryId)
                    .ToListAsync();
            }

            return View(model);
        }
    }
}
