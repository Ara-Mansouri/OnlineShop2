using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Category> Categories = new()
        {
            new Category { Id = 1, Name = "لپتاپ و تبلت", ImageUrl = "/images/categories/laptops.jpg"  },
            new Category { Id = 2, Name = "لوازم جانبی کامپیوتر", ImageUrl = "/images/categories/monitors.jpg" },
            new Category { Id = 3, Name = "هدفون و هندزفری", ImageUrl = "/images/categories/headphones.jpg" },
            new Category { Id = 4, Name = "گیمینگ", ImageUrl = "/images/categories/ps5.jpg" },
            new Category { Id = 5, Name = "موبایل", ImageUrl = "/images/categories/phones.jpg" },
            new Category { Id = 6, Name = "ساعت هوشمند", ImageUrl = "/images/categories/smartwatch.jpg" }
        };

        public IActionResult Index()
        {
            return View(Categories);
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
