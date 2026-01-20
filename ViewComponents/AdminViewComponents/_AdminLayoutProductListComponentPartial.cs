using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutProductListComponentPartial:ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutProductListComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int page = 1, int pageSize = 10)
        {
            // Toplam ürün sayısı
            var totalCount = _context.Products.Count();

            // Ürünleri sayfalı şekilde çek
            var products = _context.Products
                .Include(x => x.Category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewData["CurrentPage"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalCount"] = totalCount;

            return View(products);
        }
    }
}
