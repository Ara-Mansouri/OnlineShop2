namespace OnlineShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // You will eventually hash the password in a real-world scenario
    }
}
