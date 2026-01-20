using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;
using TechnologySite.Models;

namespace TechnologySite.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutAreaChartComponentPartial : ViewComponent
    {
        private readonly TechnologyContext _context;

        public _AdminLayoutAreaChartComponentPartial(TechnologyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // 🔹 Sales tablosundaki EN SON tarihe göre çalış
            var lastSaleDate = _context.Sales
                .Max(x => (DateTime?)x.SaleDate) ?? DateTime.Now;

            // 🔹 Son 3 ay
            var months = Enumerable.Range(0, 3)
                .Select(i => new DateTime(lastSaleDate.Year, lastSaleDate.Month, 1).AddMonths(-i))
                .OrderBy(x => x)
                .ToList();

            // 🔹 Aylık satış toplamları
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

            var model = new AdminAreaChartViewModel
            {
                Months = new List<string>(),
                RevenueTotals = new List<decimal>(),
                ExpenseTotals = new List<decimal>()
            };

            foreach (var month in months)
            {
                model.Months.Add(month.ToString("MM.yyyy"));

                var total = salesData
                    .FirstOrDefault(x => x.Year == month.Year && x.Month == month.Month)
                    ?.Total ?? 0;

                model.RevenueTotals.Add(total);

                // 🔸 Örnek: gider = %25
                model.ExpenseTotals.Add(Math.Round(total * 0.25m, 2));
            }

            // 🔹 Üstte gösterilen toplamlar
            ViewBag.v1 = model.RevenueTotals.Sum();
            ViewBag.v2 = model.ExpenseTotals.Sum();

            return View(model);
        }
    }
}
