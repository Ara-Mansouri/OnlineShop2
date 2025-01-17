using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Category
    {
        public int Id { get; set; } // Unique identifier
        public string Name { get; set; }
        public string ImageUrl { get; set; } // Image for the category
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
