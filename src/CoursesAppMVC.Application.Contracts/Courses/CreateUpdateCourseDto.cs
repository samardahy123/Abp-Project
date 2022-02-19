using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoursesAppMVC.Courses
{
    public class CreateUpdateCourseDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Guid InstructorId { get; set; }
    }
}
