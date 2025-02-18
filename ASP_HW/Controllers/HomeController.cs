using Microsoft.AspNetCore.Mvc;

namespace ASP_HW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RedirectToAnotherController()
        {
            return RedirectToAction("ShowMessage", "Redirect");
        }

        public IActionResult ShowProduct(int id)
        {
            return Content($"Ідентифікатор продукту: {id}");
        }
    }
}
