using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoursesController : ControllerBase
  {
    // _course is "course serivce" which uses the actual db context
    private readonly ICourse _course;

    public CoursesController(ICourse s)
    {
      _course = s;
    }

    // GET: api/Courses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
      // You should count the list ...
      var list = await _course.GetCourses();
      return Ok(list);
    }

    // GET: api/Courses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
      Course course = await _course.GetCourse(id);
      return course;
    }

    // PUT: api/Courses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(int id, Course course)
    {
      if (id != course.Id)
      {
        return BadRequest();
      }

      var updatedCourse = await _course.UpdateCourse(id, course);

      return Ok(updatedCourse);
    }

    // POST: api/Courses
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
      await _course.Create(course);

      // Return a 201 Header to browser
      // The body of the request will be us running GetCourse(id);
      return CreatedAtAction("GetCourse", new { id = course.Id }, course);
    }

    // DELETE: api/Courses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourses(int id)
    {
      await _course.Delete(id);
      return NoContent();
    }

    // Add a student to a course
    // POST: api/Courses/5/7
    [HttpPost]
    [Route("{courseId}/{studentId}")]
    public async Task<IActionResult> AddStudentToCourse(int courseId, int studentId)
    {
      await _course.AddStudent(courseId, studentId);
      return NoContent();
    }


  }
}
