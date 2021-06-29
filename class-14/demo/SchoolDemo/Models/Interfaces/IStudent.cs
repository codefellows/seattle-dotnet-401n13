using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models.Interfaces
{
  public interface IStudent
  {
    // Create
    Task<Student> Create(Student student);

    // Read

    // Get all
    Task<List<Student>> GetAll();

    // Get one by id
    Task<Student> GetOne(int id);

    // Update
    Task<Student> Update(int id, Student student);

    // Delete
    Task Delete(int id);

    // Add Grade
    Task AddGradeToTranscript(int studentId, Transcript grade);

  }
}
