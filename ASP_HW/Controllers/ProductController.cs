using Microsoft.AspNetCore.Mvc;
using System.Text;
using ASP_HW.Models;

namespace ASP_HW.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Phone", Price = 500, Category = "Electronics" },
            new Product { Id = 2, Name = "Laptop", Price = 1000, Category = "Electronics" },
            new Product { Id = 3, Name = "TV", Price = 2000, Category = "Electronics" }
        };

        public JsonResult GetAll()
        {
            return Json(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Content($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}");
        }

        public IActionResult DownloadPriceList()
        {
            var sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"{product.Id}, {product.Name}, {product.Price}, {product.Category}");
            }

            var byteArray = Encoding.UTF8.GetBytes(sb.ToString());
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", "priceList.txt");
        }
    }
}
