using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.DTO
{
  // This what we a course to look like in the API Results
  public class CourseDto
  {
    public string CourseCode { get; set; }
    public string Technology { get; set; }
  }
}
