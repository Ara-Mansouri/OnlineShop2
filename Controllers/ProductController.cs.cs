using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // Hardcoded list of products
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop.", Price = 1500.00M, ImageUrl = "/images/laptop.jpg" },
            new Product { Id = 2, Name = "Smartphone", Description = "A cutting-edge smartphone.", Price = 800.00M, ImageUrl = "/images/phone.jpg" },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones.", Price = 200.00M, ImageUrl = "/images/headphones.jpg" }
        };

        // Action to display the product list
        public IActionResult Index()
        {
            return View(Products);
        }

        // Action to display a specific product's details
        public IActionResult Details(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
