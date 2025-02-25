using ASP_HW.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_HW.Controllers
{
    public class CourseController : Controller
    {
        private static List<Course> courses = new List<Course>
    {
        new Course { Id = 1, Name = "C#", Description = "Learn C#", StudentsEnrolled = 30 },
        new Course { Id = 2, Name = "ASP.NET", Description = "Learn ASP.NET", StudentsEnrolled = 20 },
        new Course { Id = 3, Name = "React", Description = "Understand React framework", StudentsEnrolled = 50 },
        new Course { Id = 4, Name = "JavaScript", Description = "Learn JS", StudentsEnrolled = 40 }
    };

        [Route("courses")]
        public IActionResult Index()
        {
            return View(courses.ToList());
        }

        [Route("top-courses")]
        public IActionResult TopCourses()
        {
            var topCourses = courses.OrderByDescending(c => c.StudentsEnrolled).Take(3).ToList();
            return View(topCourses);
        }

        [Route("courses/details/{id}")]
        public IActionResult Details(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [Route("courses/enroll/{id}")]
        public IActionResult Enroll(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course != null) course.StudentsEnrolled++;
            return View("Enroll");
        }
    }
}
