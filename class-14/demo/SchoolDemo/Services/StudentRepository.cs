using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SchoolDemo.Services
{
  public class StudentRepository : IStudent
  {
    private SchoolDbContext _context;

    public StudentRepository(SchoolDbContext context)
    {
      _context = context;
    }
    public async Task<Student> Create(Student student)
    {
      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Added;
      await _context.SaveChangesAsync();
      return student;
    }

    public async Task<Student> GetOne(int id)
    {

      // Better With LINQ!
      return await _context.Students
               .Include(s => s.Enrollments)
               .ThenInclude(e => e.Course)
               .Include(s => s.Transcripts)
               .ThenInclude(t => t.Course)
               .FirstOrDefaultAsync(s => s.Id == id);


      // Manually Tying it Together ...
      /*
      Student student = await _context.Students.FindAsync(id);
      var enrollments = await _context.Enrollments.Where(x => x.StudentId == id)
                                             .Include(x => x.Course)
                                             .ToListAsync();
      student.Enrollments = enrollments;

      return student;
      */

    }

    public async Task<List<Student>> GetAll()
    {

      return await _context.Students
                     .Include(s => s.Enrollments)
                     .ThenInclude(e => e.Course)
                     .Include(s => s.Transcripts)
                     .ThenInclude(t => t.Course)
                     .ToListAsync();
    }

    public async Task<Student> Update(int id, Student student)
    {
      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      await _context.SaveChangesAsync();
      return student;
    }

    public async Task Delete(int id)
    {
      Student student = await GetOne(id);
      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }


    public async Task AddGradeToTranscript(int studentId, Transcript grade)
    {
      var transcript = new Transcript
      {
        StudentId = studentId,
        CourseId = grade.CourseId,
        Grade = grade.Grade,
        Passed = (int)grade.Grade >= 3
      };

      _context.Transcripts.Add(transcript);
      await _context.SaveChangesAsync();
    }

  }
}
