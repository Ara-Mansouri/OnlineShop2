using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Category> Categories = new()
        {
            new Category {
                Id = 1,
                Name = "Laptops",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Dell XPS 15", Description = "High-performance laptop.", Price = 1500.00M, ImageUrl = "/images/products/dell-xps15.jpg" },
                    new Product { Id = 2, Name = "MacBook Pro", Description = "Apple's flagship laptop.", Price = 2000.00M, ImageUrl = "/images/products/macbook-pro.jpg" }
                }
            },
            // Add other categories and their products here...
        };

        public IActionResult ProductsByCategory(int categoryId)
        {
            var category = Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
                return NotFound();

            return View(category);
        }
    }
}
