using CoursesAppMVC.Courses;
using CoursesAppMVC.Models;
using CoursesAppMVC.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace CoursesAppMVC.Course
{
    public class CourseAppService : CrudAppService<
            CoursesAppMVC.Models.Course,
            CourseDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCourseDto>,
        ICourseAppService
    {
        private readonly IRepository<Instructor> _instrictorRepository;

        public CourseAppService(IRepository<Models.Course, Guid> repository, IRepository<Instructor> instrictorRepository) : base(repository)
        {
            _instrictorRepository = instrictorRepository;

            GetPolicyName = CoursesAppMVCPermissions.Courses.Default;
            GetListPolicyName = CoursesAppMVCPermissions.Courses.Default;
            CreatePolicyName = CoursesAppMVCPermissions.Courses.Create;
            UpdatePolicyName = CoursesAppMVCPermissions.Courses.Edit;
            DeletePolicyName = CoursesAppMVCPermissions.Courses.Delete;

        }

        public async Task<ListResultDto<InstructorLookUpDto>> GetInstructorLookupAsync()
        {
            try
            {
                var Instructors = await _instrictorRepository.GetListAsync();

                return new ListResultDto<InstructorLookUpDto>(
                    ObjectMapper.Map<List<Instructor>, List<InstructorLookUpDto>>(Instructors)
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override async Task<CourseDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from course in queryable
                        join instructor in await _instrictorRepository.GetQueryableAsync() on course.InstructorId equals instructor.Id
                        where course.Id == id
                        select new { course, instructor };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(CoursesAppMVC.Models.Course), id);
            }

            var bookDto = ObjectMapper.Map<CoursesAppMVC.Models.Course, CourseDto>(queryResult.course);
            bookDto.InstructorName = queryResult.instructor.Name;
            return bookDto;
        }
        public override async Task<PagedResultDto<CourseDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
           
            var queryable = await Repository.GetQueryableAsync();

            var query = from course in queryable
                        join instructor in await _instrictorRepository.GetQueryableAsync() on course.InstructorId equals instructor.Id
                        select new { course, instructor };

            //Paging
            query = query
                
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

          
            var queryResult = await AsyncExecuter.ToListAsync(query);

          
            var courseDtos = queryResult.Select(x =>
            {
                var courseDto = ObjectMapper.Map<CoursesAppMVC.Models.Course, CourseDto>(x.course);
                courseDto.InstructorName = x.instructor.Name;
                return courseDto;
            }).ToList();

          
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<CourseDto>(
                totalCount,
                courseDtos
            );
        }
       
    }
}
