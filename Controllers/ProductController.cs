using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;
using TechnologySite.ViewModels;

namespace TechnologySite.Controllers
{
    public class ProductController : Controller
    {
        private readonly TechnologyContext _context;

        public ProductController(TechnologyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Category(int id)
        {
            var products = await _context.Products
                .Where(x => x.CategoryID == id)
                .ToListAsync();

            ViewBag.CategoryName =
                _context.Categories.FirstOrDefault(c => c.CategoryID == id)?.CategoryName;

            return View(products);
        }
        public async Task<IActionResult> ProductList(int? categoryId)
        {
            // Tüm kategoriler
            var categories = await _context.Categories
                .Include(c => c.Products) // istersen ürünleri eager load edebilirsin
                .ToListAsync();

            // Kategoriye göre ürünler
            var products = categoryId == null
                ? await _context.Products.ToListAsync()
                : await _context.Products.Where(p => p.CategoryID == categoryId).ToListAsync();

            var model = new ShopViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategoryId = categoryId
            };

            return View(model);
        }


        public IActionResult Index(int page = 1, int pageSize = 10)
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

        [HttpGet]
        public IActionResult AddProduct(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.v = _context.Categories
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                })
                .ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.v = _context.Categories
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                })
                .ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
