using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models
{
  public class Student
  {
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public List<Enrollment> Enrollments { get; set; }
    public List<Transcript> Transcripts { get; set; }
  }
}
