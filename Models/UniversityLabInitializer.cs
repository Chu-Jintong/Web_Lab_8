using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class UniversityLabInitializer : DropCreateDatabaseIfModelChanges<UniversityLabContext>
    {
        protected override void Seed(UniversityLabContext context)
        {
            var campuses = new List<UniversityCampus>
            {
                new UniversityCampus { Name = "Auckland" },
                new UniversityCampus { Name = "Wellington" },
                new UniversityCampus { Name = "Palmerston North" }
            };

            campuses.ForEach(c => context.UniversityCampuses.Add(c));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { Name = "Alice", Address = "Street 1", CampusId = campuses[0].Id },
                new Student { Name = "Bob", Address = "Street 2", CampusId = campuses[1].Id },
                new Student { Name = "Cindy", Address = "Street 3", CampusId = campuses[2].Id },
                new Student { Name = "David", Address = "Street 4", CampusId = campuses[0].Id }
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
        }
    }
}