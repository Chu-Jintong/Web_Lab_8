using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CampusId { get; set; }
        public virtual UniversityCampus Campus { get; set; }
    }
}