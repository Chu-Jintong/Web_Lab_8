using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public static class FakeUniversityRepository
    {
        private static readonly List<UniversityCampus> campuses = new List<UniversityCampus>
        {
            new UniversityCampus { Id = 1, Name = "Auckland" },
            new UniversityCampus { Id = 2, Name = "Wellington" },
            new UniversityCampus { Id = 3, Name = "Palmerston North" }
        };

        private static readonly List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Address = "Street 1", CampusId = 1 },
            new Student { Id = 2, Name = "Bob", Address = "Street 2", CampusId = 2 },
            new Student { Id = 3, Name = "Cindy", Address = "Street 3", CampusId = 3 },
            new Student { Id = 4, Name = "David", Address = "Street 4", CampusId = 1 }
        };

        static FakeUniversityRepository()
        {
            foreach (var campus in campuses)
            {
                campus.Students = students.Where(s => s.CampusId == campus.Id).ToList();
            }

            foreach (var student in students)
            {
                student.Campus = campuses.First(c => c.Id == student.CampusId);
            }
        }

        public static List<Student> GetStudents()
        {
            return students;
        }

        public static List<UniversityCampus> GetCampuses()
        {
            return campuses;
        }
    }
}