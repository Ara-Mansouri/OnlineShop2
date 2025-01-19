using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Extensions;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";

        private ShoppingCart GetCartFromSession()
        {
            var cart = HttpContext.Session.Get<ShoppingCart>(CartSessionKey);
            if (cart == null)
            {
                cart = new ShoppingCart();
                HttpContext.Session.Set(CartSessionKey, cart);
            }
            return cart;
        }

        private void SaveCartToSession(ShoppingCart cart)
        {
            HttpContext.Session.Set(CartSessionKey, cart);
        }

        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            return View(cart);
        }

        public IActionResult AddToCart(int productId, string productName, decimal price, string imageUrl)
        {
            var cart = GetCartFromSession();
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = 1,
                    ImageUrl = imageUrl
                });
            }
            SaveCartToSession(cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCartFromSession();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            SaveCartToSession(cart);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CartSessionKey);
            return RedirectToAction("Index");
        }
    }
}
