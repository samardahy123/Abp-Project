using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CoursesAppMVC.Students
{
    public interface IStudentAppService : ICrudAppService<
            StudentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateStudentDto>
    {
        Task<ListResultDto<StudentCourseDto>> GetStudentCourseAsync();

    }
}
