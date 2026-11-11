using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class StudentsController : Controller
    {
        private UniversityLabContext db = new UniversityLabContext();

        public ActionResult Index(string campus, string search)
        {
            var students = db.Students.Include(s => s.Campus);

            var campusList = db.UniversityCampuses
                .Select(c => c.Name)
                .ToList();

            ViewBag.Campus = new SelectList(campusList, campus);
            ViewBag.Search = search;

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.Name.Contains(search));
            }

            if (!string.IsNullOrEmpty(campus))
            {
                students = students.Where(s => s.Campus.Name == campus);
            }

            return View(students.ToList());
        }

        public ActionResult Advanced(string searchText, string campus)
        {
            var students = db.Students.Include(s => s.Campus);

            if (!string.IsNullOrEmpty(searchText))
            {
                students = students.Where(s =>
                    s.Name.Contains(searchText) ||
                    s.Address.Contains(searchText));
            }

            if (!string.IsNullOrEmpty(campus))
            {
                students = students.Where(s => s.Campus.Name == campus);
            }

            var viewModel = new StudentFilterViewModel
            {
                SearchText = searchText,
                Campus = campus,
                Campuses = db.UniversityCampuses
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == campus
                    }).ToList(),
                Students = students.ToList()
            };

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}