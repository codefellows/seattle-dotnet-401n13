using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Services.Interfaces;

namespace SchoolDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoursesController : ControllerBase
  {
    private readonly ICourse _course;

    public CoursesController(ICourse course)
    {
      _course = course;
    }

    // GET: api/Courses
    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
      return Ok(await _course.GetAll());
    }

    // GET: api/Courses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
      Course course = await _course.GetOne(id);
      return course;
    }

    // PUT: api/Courses/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(int id, Course course)
    {
      if (id != course.Id)
      {
        return BadRequest();
      }

      var updatedCourse = await _course.Update(id, course);

      return Ok(updatedCourse);

    }

    // POST: api/Courses
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
      await _course.Create(course);
      // Returns a 201 Header
      // The body will be the result of calling GetCourse with the id
      return CreatedAtAction("GetCourse", new { id = course.Id }, course);
    }

    // DELETE: api/Courses/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCourse(int id)
    {
      await _course.Delete(id);
      return NoContent();
    }

    // POST: api/Courses/5/7
    [HttpPost]
    [Route("{courseId}/{studentId}")]
    public async Task<IActionResult> AddStudentToCourse(int courseId, int studentId)
    {
      await _course.AddStudent(courseId, studentId);
      return NoContent();
    }

    // DELETE: api/Courses/5/7
    [HttpDelete]
    [Route("{courseId}/{studentId}")]
    public async Task<IActionResult> DeleteStudentFromCourse(int courseId, int studentId)
    {
      await _course.RemoveStudentFromCourse(courseId, studentId);
      return NoContent();
    }

  }
}
