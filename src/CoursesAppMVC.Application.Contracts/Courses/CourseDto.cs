using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CoursesAppMVC.Courses
{
    public class CourseDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string InstructorName { get; set; }

        public Guid InstructorId { get; set; }
       

    }
}
