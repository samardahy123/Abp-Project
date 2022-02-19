using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CoursesAppMVC.Instructors
{
    public class GetInstructorListDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    
    
    }
}
