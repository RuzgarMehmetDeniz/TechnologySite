using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;

namespace TechnologySite.ViewComponents.DefaultViewComponents
{
    public class _UserLayoutDefaultSliderComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutDefaultSliderComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var products = _context.Products
         .Where(p => p.Status == true)
         .AsEnumerable() // EF Core hatasını önler
         .GroupBy(p => p.CategoryID)
         .Select(g => g
             .OrderByDescending(p => p.Price) // 🔥 en pahalı
             .First())
         .Take(10)
         .ToList();

            // 🔹 Slider listesi
            var sliders = products
                .Select(p => new Slider
                {
                    ProductID = p.ProductID,
                    Product = p
                })
                .ToList();

            // 🔹 Slider’da kullanılan kategoriler
            var categoryIds = products
                .Select(p => p.CategoryID)
                .Distinct()
                .ToList();

            var categories = _context.Categories
                .Where(c => categoryIds.Contains(c.CategoryID))
                .ToList();

            // View’e kategori de gönder
            ViewBag.SliderCategories = categories;

            return View(sliders);
        }
    }
}
