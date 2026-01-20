using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

namespace TechnologySite.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly TechnologyContext _context;

        public AdminLayoutController(TechnologyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var now = DateTime.Now;
            var months = Enumerable.Range(0, 3)
                .Select(i => new DateTime(now.Year, now.Month, 1).AddMonths(-i))
                .OrderBy(x => x)
                .ToList();

            var salesData = _context.Sales
                .Where(x => x.SaleDate >= months.First())
                .GroupBy(x => new { x.SaleDate.Year, x.SaleDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Total = g.Sum(x => x.Amount)
                })
                .ToList();

            var labels = new List<string>();
            var values = new List<decimal>();

            foreach (var month in months)
            {
                labels.Add(month.ToString("MM/yyyy"));

                var data = salesData.FirstOrDefault(x =>
                    x.Year == month.Year && x.Month == month.Month);

                values.Add(data?.Total ?? 0);
            }

            ViewBag.Labels = labels;
            ViewBag.Values = values;

            return View();
        }
    }
}
