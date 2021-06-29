using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Models.Api;
using SchoolDemo.Models.Interfaces;

namespace SchoolDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentsController : ControllerBase
  {
    private readonly IStudent _student;

    public StudentsController(IStudent student)
    {
      _student = student;
    }

    // GET: api/Students
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
      return Ok(await _student.GetAll());
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetStudent(int id)
    {
      StudentDto student = await _student.GetOne(id);
      return student;
    }

    // PUT: api/Students/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, Student student)
    {
      if (id != student.Id)
      {
        return BadRequest();
      }

      var updatedStudent = await _student.Update(id, student);

      return Ok(updatedStudent);

    }

    // POST: api/Students
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(NewStudentDto student)
    {
      Student newStudent = await _student.Create(student);
      // Returns a 201 Header
      // The body will be the result of calling GetStudent with the id
      return CreatedAtAction("GetStudent", new { id = newStudent.Id }, newStudent);
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
      await _student.Delete(id);
      return NoContent();
    }

    // POST api/Students/5/Grades
    [HttpPost("{studentId}/Grades")]
    public async Task<ActionResult<Transcript>> AddGradeToTranscript(int studentId, [FromBody] Transcript transcript)
    {
      await _student.AddGradeToTranscript(studentId, transcript);
      return Ok();
    }
  }
}
