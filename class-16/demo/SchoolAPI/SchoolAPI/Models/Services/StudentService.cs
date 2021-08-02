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
    public async Task<StudentDto> Create(NewStudentDto inboundStudent)
    {
      // student is an instance of Sudent
      // the current state of the student object: raw
      // {  Name= "John Cokos", CourseCode }

      // Make a new student
      // Fetch the course ID from that coursecode

      Student student = new Student()
      {
        FirstName = inboundStudent.Name.Split(" ").First<string>(),
        LastName = inboundStudent.Name.Split(" ").Last<string>()
      };

      _context.Entry(student).State = EntityState.Added;
      await _context.SaveChangesAsync();

      // Now we have a student ID and a course code, but I need a course ID
      Course course = await _courses.GetCourseByCode(inboundStudent.CourseCode);

      await _courses.AddStudent(course.Id, student.Id);


      StudentDto addedSTudent = await GetStudent(student.Id);

      return addedSTudent;
    }


    // this will need to return a packaged list of students (DTO)
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

    // Return a packaged up student (DTO)
    public async Task<StudentDto> GetStudent(int id)
    {

      // Return a StudentDto instead of a Student

      // return await _context.Students
      //                     .Include(s => s.Enrollments)
      //                    .ThenInclude(e => e.Course)
      //                  .FirstOrDefaultAsync(s => s.Id == id);

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
