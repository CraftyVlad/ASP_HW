using Microsoft.AspNetCore.Mvc;
using ASP_HW.Models;

namespace ASP_HW.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Fantasy", Publisher = "Publisher 1", Year = 2025 },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Romance", Publisher = "Publisher 2", Year = 2024 },
            new Book { Id = 3, Title = "Book 3", Author = "Author 3", Genre = "Fantasy", Publisher = "Publisher 3", Year = 2023 }
        };

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Buy(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            TempData["Message"] = $"You bought: {book.Title}";
            return RedirectToAction("Index");
        }
    }
}
