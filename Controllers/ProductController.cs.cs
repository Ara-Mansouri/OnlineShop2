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
            new Category {
                Id = 2,
                Name = "لوازم جانبی کامپیوتر",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = " ماوس ایسوس c89 ", Description = "‌ ماوس بی سیم", Price =999000 , ImageUrl = "/images/products/asus_mouse.jpg", CategoryId = 2 },
                    new Product { Id = 2, Name = "MP1980 ماوس پد", Description = "ماوس پد طرح ایسوس مدل MP1980.", Price = 100000, ImageUrl = "/images/products/mouse_pad.jpg", CategoryId = 2 }
                }
            },
            new Category {
                Id = 3,
                Name = "هدفون و هندزفری",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = " هدفون بلوتوثی T13 ", Description = "‌ هدفون بلوتوثی کیو سی وای مدل T13 TWS", Price =750000 , ImageUrl = "/images/products/T13.jpg", CategoryId = 3 },
                    new Product { Id = 2, Name = "هدفون بلوتوثی مدل گربه ای", Description = "هدفون MZ-023 ", Price = 229000, ImageUrl = "/images/products/cat.jpg", CategoryId = 3 }
                }
            },
            new Category {
                Id = 4,
                Name = "گیمینگ",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = " PlayStation 5 ", Description = "‌ناموجودکنسول بازی سونی مدل PlayStation 5 ظرفیت 825 گیگابایت ریجن 1200 آسیا\n", Price =8790000 , ImageUrl = "/images/products/PS5.jpg", CategoryId = 4 },
                    new Product { Id = 2, Name = "دسته بازی تسکو", Description = "دسته بازی بی سیم تسکو مدل TG 159W ", Price = 168000, ImageUrl = "/images/products/WGC.jpg", CategoryId = 4 }
                }
            },
            new Category {
                Id = 5,
                Name = " موبایل ",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = " Redmi Note 13 Pro 5G ", Description = "‌ گوشی موبایل شیائومی مدل Redmi Note 13 Pro 5G دو سیم کارت ظرفیت 512 گیگابایت و رم 12 گیگابایت", Price =23000000 , ImageUrl = "/images/products/Redmi.jpg", CategoryId = 5 },
                    new Product { Id = 2, Name = "iPhone 13 CH", Description = "گوشی موبایل اپل مدل iPhone 13 CH دو سیم‌ کارت ظرفیت 128 گیگابایت و رم 4 گیگابایت - نات اکتیو ", Price = 48000000, ImageUrl = "/images/products/iphone.jpg", CategoryId = 5 }
                }
            },
            new Category {
                Id = 6,
                Name = "ساعت هوشمند",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "دمچ بند هوشمند شیائومی", Description = "مچ بند هوشمند شیائومی مدل Mi Band 8 گلوبال\n ", Price = 1865000, ImageUrl = "/images/products/smartwatch.jpg", CategoryId = 6 }
                }
            }      
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
