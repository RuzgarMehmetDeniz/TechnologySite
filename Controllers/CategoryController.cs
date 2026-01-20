using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;
using TechnologySite.Models;

namespace TechnologySite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TechnologyContext _context;

        public CategoryController(TechnologyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CategoryList()
        {
            var model = new IndexViewModel
            {
                Categories = await _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToListAsync()
            };

            return View(model);
        }

        public IActionResult ProductsByCategory(int id)
        {
            var model = new CategoryProductViewModel
            {
                CategoryID = id
            };

            return View(model);
        }
        public IActionResult CategoryIndex()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return View("CategoryIndex");
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return View("CategoryIndex");
        }

    }
}
