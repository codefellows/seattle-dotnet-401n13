using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using SchoolAPI.Models.DTO;
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
    private ICourse _courses;

    public StudentService(SchoolDbContext context, ICourse courseService)
    {
      _context = context;
      _courses = courseService;

    }
    public async Task<StudentDto> Create(NewStudentDto inboundData)
    {

      // Add the student
      Student student = new Student()
      {
        FirstName = inboundData.Name.Split(" ").First<string>(),
        LastName = inboundData.Name.Split(" ").Last<string>()
      };

      _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Added;
      await _context.SaveChangesAsync();

      // Use the Courses Service to get a course from the course service
      Course course = await _courses.GetCourseByCode(inboundData.CourseCode);

      // Use the Courses Service to add an enrollment for the student and course
      await _courses.AddStudent(course.Id, student.Id);

      StudentDto addedStudent = await GetStudent(student.Id);

      return addedStudent;

    }


    public async Task<List<StudentDto>> GetStudents()
    {
      // var students = await _context.Students.ToListAsync();
      // return students;

      return await _context.Students
        .Select(student => new StudentDto
        {
          Id = student.Id,
          FirstName = student.FirstName,
          LastName = student.LastName,
          Courses = student.Enrollments
              .Select(t => new CourseDto
              {
                CourseCode = t.Course.CourseCode,
                Technology = t.Course.Technology.Name
              }).ToList()
        }).ToListAsync();

    }

    public async Task<StudentDto> GetStudent(int id)
    {

      return await _context.Students
        .Select(student => new StudentDto
          {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Courses = student.Enrollments
              .Select(t => new CourseDto
                {
                  CourseCode = t.Course.CourseCode,
                  Technology = t.Course.Technology.Name
                }).ToList()
          }).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student> UpdateStudent(int id, Student student)
    {
      _context.Entry(student).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return student;
    }

    public async Task Delete(int id)
    {
       Student student = await _context.Students.FindAsync(id);
      _context.Entry(student).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

  }
}
