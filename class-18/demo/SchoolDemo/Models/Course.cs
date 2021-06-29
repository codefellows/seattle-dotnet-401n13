using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
  public class Course
  {
    public int Id { get; set; }
    [Required]
    public string CourseCode { get; set; }
    public int TechnologyId { get; set; }
    public float Price { get; set; }

    public List<Enrollment> Enrollments { get; set; }

    public Technology Technology { get; set; }

  }
}
