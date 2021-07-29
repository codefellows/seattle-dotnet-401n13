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
      // var students = await _context.Students.ToListAsync();
      // return students;

      return await _context.Students
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .ToListAsync();
    }

    public async Task<Student> GetStudent(int id)
    {

      // Student student = await _context.Students.FindAsync(id);
      // return student;

      // Student student = await _context.Students.FindAsync(id);
      // var enrollments = await _context.Enrollments.Where(x => x.StudentId == id)
      //                                            .Include(x => x.Course)
      //                                            .ToListAsync();

      // student.Enrollments = enrollments;
      // return student;

      // Now with a mondo linq query

      return await _context.Students
                           .Include(s => s.Enrollments)
                           .ThenInclude(e => e.Course)
                           .FirstOrDefaultAsync(s => s.Id == id);


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
