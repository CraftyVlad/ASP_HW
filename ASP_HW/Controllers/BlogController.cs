using Microsoft.AspNetCore.Mvc;
using ASP_HW.Models;

namespace ASP_HW.Controllers
{
    public class BlogController : Controller
    {
        private static List<Blog> Articles = new List<Blog>
    {
        new Blog { Slug = "aspnet-guide", Title = "ASP.NET guide", Name = "John" },
        new Blog { Slug = "csharp-guide", Title = "C# guide", Name = "Bob" },
        new Blog { Slug = "advanced-aspnet", Title = "Advanced ASP.NET", Name = "Jake" },
        new Blog { Slug = "entity-framework-tops", Title = "Entity framework tips", Name = "John" }
    };

        [Route("blog")]
        public IActionResult Index() => Redirect("/blog/latest");

        [Route("blog/latest")]
        public IActionResult Latest() => View("Index", Articles.Take(3).ToList());

        [Route("blog/{slug}")]
        public IActionResult Article(string slug)
        {
            var article = Articles.FirstOrDefault(s => s.Slug == slug);
            if (article == null) return NotFound();
            return View(article);
        }

        [Route("blog/author/{name:regex([[a-zA-Z]]+)}")]
        public IActionResult Author(string? name)
        {
            var authorArticles = Articles.Where(a => a.Name == name).ToList();
            if (!authorArticles.Any()) return NotFound();
            return View(authorArticles);
        }
    }
}