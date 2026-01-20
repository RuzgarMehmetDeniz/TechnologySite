using Microsoft.AspNetCore.Mvc;
using TechnologySite.Context;

public class ProductPriceCompareViewComponent : ViewComponent
{
    private readonly TechnologyContext _context;

    public ProductPriceCompareViewComponent(TechnologyContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var model = new ProductPriceCompareVM
        {
            CheapestProducts = _context.Products
                .OrderBy(x => x.Price)
                .Take(5)
                .ToList(),

            MostExpensiveProducts = _context.Products
                .OrderByDescending(x => x.Price)
                .Take(5)
                .ToList()
        };

        return View(model);
    }
}
