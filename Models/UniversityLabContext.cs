using System.Data.Entity;

namespace WebApplication1.Models
{
    public class UniversityLabContext : DbContext
    {
        public UniversityLabContext() : base("UniversityLabContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<UniversityCampus> UniversityCampuses { get; set; }
    }
}