using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Data;
using SchoolDemo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SchoolDemo.Models.Interfaces.Services
{
  public class StudentRepository : IStudent
  {
    private SchoolDbContext _context;

    // This is "The Injection" of context
    public StudentRepository(SchoolDbContext context)
    {
      _context = context;
    }
    public async Task<Student> Create(Student student)
    {
      // I have a student and I want to add them to the database
      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Added;

      // This could take a while. Open a thread and put it in, I'll wait
      // After this happens, it's a "real" thing and then gets associated with an id
      await _context.SaveChangesAsync();

      // Followign the async call, we can return the studen
      return student;
    }

    public async Task Delete(int id)
    {
      Student student = await GetStudent(id);
      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<Student> GetStudent(int id)
    {
      // The system knows we have a primary key and will use it
      Student student = await _context.Students.FindAsync(id);
      return student;
    }

    public async Task<List<Student>> GetStudents()
    {
      var students = await _context.Students.ToListAsync();
      return students;
    }

    public async Task<Student> UpdateStudent(int id, Student student)
    {
      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      await _context.SaveChangesAsync();
      return student;
    }
  }
}
