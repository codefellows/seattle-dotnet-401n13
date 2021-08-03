using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
  public class Enrollment
  {
    public int CourseId { get; set; }
    public int StudentId { get; set; }

    // Navigation Properties
    // Specifies our linkages between the tables
    public Student Student { get; set; }
    public Course Course { get; set; }
  }
}
