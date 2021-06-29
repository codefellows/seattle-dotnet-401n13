using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
  public class Transcript
  {
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public GradeValue Grade { get; set; }
    public bool Passed { get; set; }

    //  Navigation Properties
    public Student Student { get; set; }
    public Course Course { get; set; }
  }

  public enum GradeValue
  {
    A = 4,
    B = 3,
    C = 2,
    D = 1,
    F = 0
  }
}
