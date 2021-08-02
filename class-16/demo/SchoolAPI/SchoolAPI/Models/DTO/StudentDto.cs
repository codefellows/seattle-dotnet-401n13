using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.DTO
{
  // This is how a student should look in the API Results
  public class StudentDto
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<CourseDto> Courses { get; set; }
  }
}
