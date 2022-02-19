using CoursesAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace CoursesAppMVC.Students
{
    public class StudentAppService : CrudAppService<
            CoursesAppMVC.Models.Student,
            StudentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateStudentDto>,
        IStudentAppService
    {
        private readonly IRepository<CoursesAppMVC.Models.Course> _courseRepository;

        public StudentAppService(IRepository<Student, Guid> repository, IRepository<CoursesAppMVC.Models.Course> courseRepository) : base(repository)
        {
            _courseRepository = courseRepository;
        }

        public override async Task<PagedResultDto<StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var queryable = await Repository.GetQueryableAsync();

            var query = from student in queryable
                        join course in await _courseRepository.GetQueryableAsync() on student.CourseId equals course.Id
                        select new { course, student };

            //Paging
            query = query

                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);


            var queryResult = await AsyncExecuter.ToListAsync(query);


            var StudentDtos = queryResult.Select(x =>
            {
                var StudentDto = ObjectMapper.Map<CoursesAppMVC.Models.Student,StudentDto>(x.student);
                StudentDto.CourseName = x.course.Name;
                return StudentDto;
            }).ToList();


            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<StudentDto>(
                totalCount,
                StudentDtos
            );
        }
        public async Task<ListResultDto<StudentCourseDto>> GetStudentCourseAsync()
        {
            try
            {
                var Courses = await _courseRepository.GetListAsync();

                return new ListResultDto<StudentCourseDto>(
                    ObjectMapper.Map<List<CoursesAppMVC.Models.Course>, List<StudentCourseDto>>(Courses)
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override async Task<StudentDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from stuent in queryable
                        join course in await _courseRepository.GetQueryableAsync() on stuent.CourseId equals course.Id
                        where stuent.Id == id
                        select new { course, stuent };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(CoursesAppMVC.Models.Student), id);
            }

            var bookDto = ObjectMapper.Map<CoursesAppMVC.Models.Student, StudentDto>(queryResult.stuent);
            bookDto.CourseName = queryResult.course.Name;
            return bookDto;
        }


    }
}
