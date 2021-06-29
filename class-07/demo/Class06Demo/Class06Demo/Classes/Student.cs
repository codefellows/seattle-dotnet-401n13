using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Classes
{
    class Student : Person
    {
        public double GPA { get; set; }
        public string[] Courses { get; set; }

        public Student()
        {
            Courses = new string[3];
        }

        public double CalculateGPA()
        {
            return 4.0;
        }

        public string PrintGrades()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Courses.Length; i++)
            {
                sb.Append(Courses[i]);
            }

            return sb.ToString();
        }

        public void AddCourse(string courseName)
        {
            // logic to course to array. resize if needed
        }

    }
}
