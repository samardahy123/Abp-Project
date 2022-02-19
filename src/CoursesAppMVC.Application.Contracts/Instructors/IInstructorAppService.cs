using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CoursesAppMVC.Instructors
{
    public interface IInstructorAppService : ICrudAppService<
            InstructorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateInstructorDto>
    {
       // Task<ListResultDto<InstructorDto>> GetListAsync();

    }
}
