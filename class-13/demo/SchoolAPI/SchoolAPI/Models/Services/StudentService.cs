using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using SchoolAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Services
{
  public class StudentService : IStudent
  {

    private SchoolDbContext _context;

    public StudentService(SchoolDbContext context)
    {
      _context = context;
    }
    public async Task<Student> Create(Student student)
    {
      // student is an instance of Sudent
      // the current state of the student object: raw

      _context.Entry(student).State = EntityState.Added;
      // the current state of the student object: added

      await _context.SaveChangesAsync();

      return student;
    }


    public async Task<List<Student>> GetStudents()
    {
      var students = await _context.Students.ToListAsync();
      return students;
    }

    public async Task<Student> GetStudent(int id)
    {
      Student student = await _context.Students.FindAsync(id);
      return student;
    }

    public async Task<Student> UpdateStudent(int id, Student student)
    {
      _context.Entry(student).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return student;
    }

    public async Task Delete(int id)
    {
      Student student = await GetStudent(id);
      _context.Entry(student).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

  }
}
