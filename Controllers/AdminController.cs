using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologySite.Context;
using TechnologySite.Entities;

public class AdminController : Controller
{
    private readonly TechnologyContext _context;

    public AdminController(TechnologyContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Orders()
    {
        var orders = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.User)
            .ToListAsync();

        return View(orders);
    }
}
