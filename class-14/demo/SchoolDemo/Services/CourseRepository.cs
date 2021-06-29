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
  public class CourseRepository : ICourse
  {
    private SchoolDbContext _context;

    public CourseRepository(SchoolDbContext context)
    {
      _context = context;
    }
    public async Task<Course> Create(Course course)
    {
      _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Added;
      await _context.SaveChangesAsync();
      return course;
    }

    public async Task<Course> GetOne(int id)
    {

      return await _context.Courses
         .Include(s => s.Enrollments)
         .ThenInclude(e => e.Student)
         .FirstOrDefaultAsync(s => s.Id == id);

    }

    public async Task<List<Course>> GetAll()
    {

      return await _context.Courses
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Student)
        .ToListAsync();

    }

    public async Task<Course> Update(int id, Course course)
    {
      _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      await _context.SaveChangesAsync();
      return course;
    }

    public async Task Delete(int id)
    {
      Course course = await GetOne(id);
      _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task AddStudent(int courseId, int studentId)
    {

      Enrollment enrollment = new Enrollment()
      {
        CourseId = courseId,
        StudentId = studentId
      };

      _context.Entry(enrollment).State = EntityState.Added;
      await _context.SaveChangesAsync();

    }

    public async Task RemoveStudentFromCourse(int courseId, int studentId)
    {
      // Find me the record where the course and student match our request
      var result = await _context.Enrollments.FirstOrDefaultAsync(x => x.CourseId == courseId && x.StudentId == studentId);

      _context.Entry(result).State = EntityState.Deleted;

      await _context.SaveChangesAsync();

    }

  }
}
