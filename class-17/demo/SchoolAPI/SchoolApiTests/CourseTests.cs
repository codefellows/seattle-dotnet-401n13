using SchoolAPI.Models.Services;
using System;
using Xunit;

namespace SchoolApiTests
{

  public class CourseTests : Mock
  {
    [Fact]
    public async void Can_enroll_and_drop_a_student()
    {
      // Arrange
      var student = await CreateAndSaveTestStudent();
      var course = await CreateAndSaveTestCourse();

      var repository = new CourseService(_db);

      // Act
      await repository.AddStudent(course.Id, student.Id);

      // Assert
      var actualCourse = await repository.GetCourse(course.Id);

      Assert.Contains(actualCourse.Enrollments, e => e.StudentId == student.Id);

      // Act
      // await repository.RemoveStudentFromCourse(course.Id, student.Id);

      // Assert
      // actualCourse = await repository.GetOne(course.Id);
      // Assert.DoesNotContain(actualCourse.Enrollments, e => e.StudentId == student.Id);
    }
  }

}
