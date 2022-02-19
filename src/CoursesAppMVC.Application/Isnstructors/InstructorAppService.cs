
using CoursesAppMVC.Instructors;
using CoursesAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CoursesAppMVC.Isnstructors
{
    public class InstructorAppService : CrudAppService<
            CoursesAppMVC.Models.Instructor,
            InstructorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateInstructorDto>,
        IInstructorAppService
    {
        private readonly IRepository<Instructor> _instrictorRepository;

        public InstructorAppService(IRepository<Instructor, Guid> repository, IRepository<Instructor> instrictorRepository) : base(repository)
        {
            _instrictorRepository = instrictorRepository;
        }

        public override async Task<PagedResultDto<InstructorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //var Instructors = await _instrictorRepository.GetListAsync();

            //return new ListResultDto<InstructorDto>(
            //    ObjectMapper.Map<List<Instructor>, List<InstructorDto>>(Instructors)
            //);


            var queryable = await Repository.GetQueryableAsync();

            var query = from instructor in queryable
                        select new { instructor };

            //Paging
            query = query

                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);


            var instructorDtos = queryResult.Select(x =>
            {
                var instructorDto = ObjectMapper.Map<CoursesAppMVC.Models.Instructor, InstructorDto>(x.instructor);
              
                return instructorDto;
            }).ToList();


            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<InstructorDto>(
                totalCount,
                instructorDtos
            );
        }
       
        
    }
}
