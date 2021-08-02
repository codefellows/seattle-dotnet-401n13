using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Interfaces
{
  public interface IStudent
  {
    // CREATE
    Task<Student> Create(Student student);

    // GET ALL

    Task<List<Student>> GetStudents();

    // GET ONE BY ID
    Task<Student> GetStudent(int id);

    // UPDATE
    Task<Student> UpdateStudent(int id, Student student);

    // DELETE
    Task Delete(int id);
  }
}
