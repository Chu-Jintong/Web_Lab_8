using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class StudentFilterViewModel
    {
        public string SearchText { get; set; }
        public string Campus { get; set; }
        public List<SelectListItem> Campuses { get; set; }
        public List<Student> Students { get; set; }
    }
}