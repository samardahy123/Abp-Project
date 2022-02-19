using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesAppMVC.Students
{
    public class CreateUpdateStudentDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Guid CourseId { get; set; }
    }
}
