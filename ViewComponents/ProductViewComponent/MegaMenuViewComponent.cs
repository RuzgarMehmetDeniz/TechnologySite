using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;

public class MegaMenuViewComponent : ViewComponent
{
    private readonly TechnologyContext _context;

    public MegaMenuViewComponent(TechnologyContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _context.Categories
            .Include(x => x.Products)
            .ToListAsync();

        return View(categories);
    }
}
