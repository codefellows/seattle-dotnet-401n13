using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
  // This is a PURE join table/entity
  public class Enrollment
  {
    public int CourseId { get; set; }
    public int StudentId { get; set; }

    // Navigation Properties
    // These specify the link between these tables
    public Student Student { get; set; }
    public Course Course { get; set; }
  }
}
