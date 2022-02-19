using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CoursesAppMVC.Students
{
    public class StudentDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
