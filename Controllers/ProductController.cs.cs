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
                Name = "لپتاپ",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = " لپ تاپ ایسوس 15.6 اینچی مدل VivoBook 15 X1502ZA i7 ۱۲۷۰۰H 24GB ", Description = "لپ‌تاپ ۱۵.۶ اینچی ایسوس Vivobook 15 X1502ZA: اقتصادی و کاربردی", Price =45450000 , ImageUrl = "/images/products/vivabook.jpg", CategoryId = 1 },
                    new Product { Id = 2, Name = "MacBook Pro", Description = "Apple's flagship laptop.", Price = 2000.00M, ImageUrl = "/images/products/macbook-pro.jpg", CategoryId = 1 }
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
        public IActionResult Details(int id)
        {
            var product = Categories
                .SelectMany(c => c.Products)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}
