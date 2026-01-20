using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using TechnologySite.Context;
using TechnologySite.Entities;

[Authorize]
public class CartController : Controller
{
    private readonly TechnologyContext _context;

    public CartController(TechnologyContext context)
    {
        _context = context;
    }

    // 🛒 Sepet Sayfası
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        return View(cart?.CartItems.ToList() ?? new List<CartItem>());
    }

    // ➕ Sepete Ürün Ekle
    public async Task<IActionResult> AddToCart(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserID = userId,
                CartItems = new List<CartItem>()
            };
            _context.Carts.Add(cart);
        }

        var item = cart.CartItems.FirstOrDefault(ci => ci.ProductID == productId);
        if (item != null)
            item.Quantity++;
        else
            cart.CartItems.Add(new CartItem { ProductID = productId, Quantity = 1 });

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // ➕ Adet Artır
    public async Task<IActionResult> IncreaseQuantity(int cartItemId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cartItem = await _context.CartItems
            .Include(ci => ci.Cart)
            .FirstOrDefaultAsync(ci => ci.CartItemID == cartItemId && ci.Cart.UserID == userId);

        if (cartItem != null)
        {
            cartItem.Quantity++;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    // ➖ Sepetten Çıkar
    public async Task<IActionResult> RemoveFromCart(int cartItemId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var cartItem = await _context.CartItems
            .Include(ci => ci.Cart)
            .FirstOrDefaultAsync(ci => ci.CartItemID == cartItemId && ci.Cart.UserID == userId);

        if (cartItem != null)
        {
            if (cartItem.Quantity > 1)
                cartItem.Quantity--;
            else
                _context.CartItems.Remove(cartItem);

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    // 💳 Ödeme Sayfası (GET)
    public async Task<IActionResult> Payment()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return RedirectToAction("Login", "Account");

        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        if (cart == null || !cart.CartItems.Any())
            return RedirectToAction("Index");

        return View(cart.CartItems.ToList());
    }

    // POST GoToPayment (formdan)
    [HttpPost]
    public IActionResult GoToPayment()
    {
        return RedirectToAction("Payment");
    }

    // 🛒 Checkout (ödeme yap)
    [HttpPost]
    public async Task<IActionResult> Checkout(string paymentMethod, int installments = 1)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return RedirectToAction("Login", "Account");

        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        if (cart == null || cart.CartItems.Count == 0)
            return RedirectToAction("Index");

        decimal totalAmount = cart.CartItems.Sum(c => c.Product.Price * c.Quantity);

        // 🟢 Burada Order oluştur!
        var order = new Order
        {
            UserID = userId,
            CreatedDate = DateTime.Now,
            TotalPrice = totalAmount,
            OrderItems = cart.CartItems.Select(ci => new OrderItem
            {
                ProductID = ci.ProductID,
                Quantity = ci.Quantity,
                Price = ci.Product.Price
            }).ToList()
        };

        _context.Orders.Add(order);

        // Sepeti siliyoruz
        _context.CartItems.RemoveRange(cart.CartItems);
        _context.Carts.Remove(cart);

        await _context.SaveChangesAsync();

        TempData["SelectedPayment"] = paymentMethod;
        TempData["SelectedInstallments"] = installments;
        TempData["TotalAmount"] = totalAmount.ToString("C", new CultureInfo("tr-TR"));

        return RedirectToAction("OrderSuccess");
    }


    // ✅ Ödeme Başarılı
    [HttpGet]
    public IActionResult OrderSuccess()
    {
        return View();
    }

    // ✅ Checkout GET için /Cart/Checkout
    [HttpGet]
    public async Task<IActionResult> Checkout()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return RedirectToAction("Login", "Account");

        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        if (cart == null || !cart.CartItems.Any())
            return RedirectToAction("Index");

        return View("Payment", cart.CartItems.ToList());
    }

}
