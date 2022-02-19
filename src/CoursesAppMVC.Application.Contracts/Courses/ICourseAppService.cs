using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CoursesAppMVC.Courses
{
    public interface ICourseAppService : ICrudAppService< 
            CourseDto, 
            Guid,
            PagedAndSortedResultRequestDto, 
            CreateUpdateCourseDto>
    {
        Task<ListResultDto<InstructorLookUpDto>> GetInstructorLookupAsync();

    }
}
