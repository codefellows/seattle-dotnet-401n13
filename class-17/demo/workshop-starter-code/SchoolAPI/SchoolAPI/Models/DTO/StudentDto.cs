using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.DTO
{
  public class StudentDto
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<CourseDto> Courses { get; set; }
  }

  public class CourseDto
  {
    public string CourseCode { get; set; }
    public string Technology { get; set; }
  }

  public class NewStudentDto
  {
    [Required]
    public string Name { get; set; }
    public DateTime Dob { get; set; }
    public string CourseCode { get; set; }
  }

  public class StudentGradeDto
  {
    public string CourseCode { get; set; }
    public string Grade { get; set; }
  }

}
