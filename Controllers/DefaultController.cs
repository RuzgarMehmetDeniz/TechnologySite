using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;
using TechnologySite.Models;

namespace TechnologySite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly TechnologyContext _context;

        public DefaultController(TechnologyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            int[] categoryIds = { 4, 1, 8, 12, 7, 5, 3, 9 };

            var products = await _context.Products
                .Where(p => p.Status == true && categoryIds.Contains(p.CategoryID))
                .GroupBy(p => p.CategoryID)
                .Select(g => g.OrderByDescending(p => p.Price).FirstOrDefault())
                .ToListAsync();

            var topSliders = await _context.TopSliders
                .Where(x => x.Status)
                .OrderBy(x => x.Order)
                .Include(x => x.Product)
                .Take(5)
                .ToListAsync();

            var model = new IndexViewModel
            {
                Products = products,
                Footers = await _context.Footers.ToListAsync(),
                Categories = await _context.Categories.Take(10).ToListAsync(),
                TopSliders = topSliders
            };

            return View(model);
        }


        public IActionResult DefaultPage()
        {
            var list = _context.Footers.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult UpdateDefault(int id)
        {
            var value = _context.Footers.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateDefault(Footer footer)
        {
            _context.Footers.Update(footer);
            _context.SaveChanges();
            return RedirectToAction("DefaultPage");
        }
        [HttpGet]
        public IActionResult CreateDefault()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDefault(Footer footer)
        {
            footer.DateTime = DateTime.Now;
            _context.Footers.Add(footer);
            _context.SaveChanges();
            return RedirectToAction("DefaultPage");
        }
        public IActionResult DeleteDefault(int id)
        {
            var value = _context.Footers.Find(id);
            _context.Footers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("DefaultPage");
        }
       
    }
}
