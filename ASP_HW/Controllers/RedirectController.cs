using Microsoft.AspNetCore.Mvc;

namespace ASP_HW.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult ShowMessage()
        {
            return Content("Це повідомлення з іншого контролера");
        }

        public IActionResult RedirectWithParams(int id)
        {
            return RedirectToAction("ShowProduct", "Home", new { id });
        }
    }
}
