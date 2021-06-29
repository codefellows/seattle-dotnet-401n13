using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models.Interfaces
{
  public interface IStudent
  {
    // Contains methods and properties our classes are required to implement

    // Create
    Task<Student> Create(Student student);

    // Read

    // Get all
    Task<List<Student>> GetStudents();

    // Get one by id
    Task<Student> GetStudent(int id);

    // Update
    Task<Student> UpdateStudent(int id, Student student);

    // Delete
    Task Delete(int id);

  }
}
