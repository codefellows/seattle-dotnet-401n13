using SchoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Services.Interfaces
{
  public interface ICourse
  {
    // Contains methods and properties our classes are required to implement

    // Create
    Task<Course> Create(Course course);

    // Read

    // Get all
    Task<List<Course>> GetAll();

    // Get one by id
    Task<Course> GetOne(int id);

    // Get one by Course Code
    Task<Course> GetOneByCourseCode(string courseCode);

    // Update
    Task<Course> Update(int id, Course course);

    // Delete
    Task Delete(int id);

    Task AddStudent(int courseId, int studentId);

    Task RemoveStudentFromCourse(int courseId, int studentId);

  }
}
