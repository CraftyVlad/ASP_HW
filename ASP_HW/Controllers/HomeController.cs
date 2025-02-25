using Microsoft.AspNetCore.Mvc;

namespace ASP_HW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
