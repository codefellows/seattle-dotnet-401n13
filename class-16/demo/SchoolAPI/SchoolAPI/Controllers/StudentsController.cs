using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using SchoolAPI.Models;
using SchoolAPI.Models.Interfaces;

namespace SchoolAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentsController : ControllerBase
  {
    // _student is "student serivce" which uses the actual db context
    private readonly IStudent _student;

    public StudentsController(IStudent s)
    {
      _student = s;
    }

    // GET: api/Students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
      // You should count the list ...
      var list = await _student.GetStudents();
      return Ok(list);
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
      Student student = await _student.GetStudent(id);
      return student;
    }

    // PUT: api/Students/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, Student student)
    {
      if (id != student.Id)
      {
        return BadRequest();
      }

      var updatedStudent = await _student.UpdateStudent(id, student);

      return Ok(updatedStudent);
    }

    // POST: api/Students
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
      await _student.Create(student);

      // Return a 201 Header to browser
      // The body of the request will be us running GetStudent(id);
      return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
      await _student.Delete(id);
      return NoContent();
    }

  }
}
