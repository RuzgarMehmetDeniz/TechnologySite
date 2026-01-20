using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechnologySite.Context;

namespace TechnologySite.ViewComponents.CartViewComponent
{
    public class _UserLayoutCartListComponentPartial:ViewComponent
    {
        private readonly TechnologyContext _context;

        public _UserLayoutCartListComponentPartial(TechnologyContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return View(0); // Giriş yapmamışsa 0
            }

            var count = await _context.Carts
                .Include(c => c.CartItems)
                .Where(c => c.UserID == userId)
                .SelectMany(c => c.CartItems)
                .SumAsync(ci => (int?)ci.Quantity) ?? 0; // Sepet boşsa 0

            return View(count);
        }
    }
}
