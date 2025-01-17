using Microsoft.AspNetCore.Http; // Add this namespace for session management
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System.Linq;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        // A simple in-memory "database" for demonstration purposes
        private static readonly List<User> Users = new();

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Store the username in the session
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (Users.Any(u => u.Username == username))
            {
                ViewBag.ErrorMessage = "Username is already taken.";
                return View();
            }

            var newUser = new User { Username = username, Password = password };
            Users.Add(newUser);
            // Store the username in the session after registration
            HttpContext.Session.SetString("Username", newUser.Username);
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // Remove the username from the session on logout
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Home");
        }
    }
}
