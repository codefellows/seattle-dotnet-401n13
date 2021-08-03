using SchoolAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Interfaces
{
  public interface IStudent
  {
    // CREATE
    Task<StudentDto> Create(NewStudentDto student);

    // GET ALL

    Task<List<StudentDto>> GetStudents();

    // GET ONE BY ID
    Task<StudentDto> GetStudent(int id);

    // UPDATE
    Task<Student> UpdateStudent(int id, Student student);

    // DELETE
    Task Delete(int id);
  }
}
