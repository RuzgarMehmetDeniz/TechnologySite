using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;
using TechnologySite.Entities;

namespace TechnologySite.Controllers
{
    public class TopSliderController : Controller
    {
        private readonly TechnologyContext _context;

        public TopSliderController(TechnologyContext context)
        {
            _context = context;
        }

        public IActionResult TopSlider()
        {
            var values = _context.TopSliders.ToList();
            return View(values);
        }
        public IActionResult DeleteTopSlider(int id)
        {
            var values = _context.TopSliders.Find(id);
            _context.TopSliders.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("TopSlider");
        }
        [HttpGet]
        public IActionResult AddTopSlider()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult AddTopSlider(TopSlider topSlider)
        {
            _context.TopSliders.Add(topSlider);
            _context.SaveChanges();
            return RedirectToAction("TopSlider");
        }

        [HttpGet]
        public IActionResult UpdateTopSlider(int id)
        {
            var value = _context.TopSliders.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTopSlider(TopSlider topSlider)
        {
            _context.TopSliders.Update(topSlider);
            _context.SaveChanges();
            return RedirectToAction("TopSlider");
        }
    }
}
