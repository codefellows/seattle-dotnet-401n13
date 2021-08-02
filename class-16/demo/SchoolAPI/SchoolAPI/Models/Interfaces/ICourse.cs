using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Interfaces
{
  public interface ICourse
  {
    // CREATE
    Task<Course> Create(Course course);

    // GET ALL

    Task<List<Course>> GetCourses();

    // GET ONE BY ID
    Task<Course> GetCourse(int id);

    // UPDATE
    Task<Course> UpdateCourse(int id, Course course);

    // DELETE
    Task Delete(int id);

    // ADD STUDENT
    Task AddStudent(int courseId, int studentId);

  }
}
