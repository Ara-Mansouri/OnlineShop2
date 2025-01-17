using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Category
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
