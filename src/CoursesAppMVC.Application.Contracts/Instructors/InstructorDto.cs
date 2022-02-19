using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CoursesAppMVC.Instructors
{
    public class InstructorDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string ShortBio { get; set; }
    }
}
