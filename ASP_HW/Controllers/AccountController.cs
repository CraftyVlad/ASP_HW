using Microsoft.AspNetCore.Mvc;
using ASP_HW.Models;

namespace ASP_HW.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Username) &&
                !string.IsNullOrWhiteSpace(model.Password) &&
                model.Password == model.ConfirmPassword &&
                !string.IsNullOrWhiteSpace(model.Email))
            {
                return RedirectToAction("Profile", "Account", new { username = model.Username });
            }

            return View("Register", model);
        }

        [HttpGet]
        public IActionResult Profile(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Register", "Account");
            }

            var userProfile = new UserProfileViewModel
            {
                Username = username,
                Email = "user@example.com",
                IsVerified = false
            };

            return View("Profile", userProfile);
        }
    }
}