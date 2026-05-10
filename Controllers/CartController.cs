using ASP.NET_GameStore.Data;
using ASP.NET_GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASP.NET_GameStore.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private const string CartKey = "Cart";

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartKey);
            return cartJson == null ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString(CartKey, JsonSerializer.Serialize(cart));
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        public IActionResult Add(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null) return NotFound();

            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.GameId == id);

            if (existing != null)
                existing.Quantity++;
            else
                cart.Add(new CartItem { GameId = id, Title = game.Title, Price = game.Price, Quantity = 1 });

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            cart.RemoveAll(c => c.GameId == id);
            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}