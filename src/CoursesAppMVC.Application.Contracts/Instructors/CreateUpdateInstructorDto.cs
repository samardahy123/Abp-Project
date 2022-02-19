using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoursesAppMVC.Instructors
{
    public class CreateUpdateInstructorDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortBio { get; set; }
    }
}
