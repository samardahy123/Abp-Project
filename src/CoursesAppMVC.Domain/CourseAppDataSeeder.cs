using CoursesAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CoursesAppMVC
{
    public class CourseAppDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly IRepository<Student, Guid> _studentRepository;
        public CourseAppDataSeeder(IRepository<Course, Guid> courseRepository, IRepository<Instructor, Guid> instructorRepository, IRepository<Student, Guid> studentRepository)
        {
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _studentRepository =studentRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _courseRepository.GetCountAsync() > 0)
            {
                return;
            }

            var Instructor= await _instructorRepository.InsertAsync(
             new Instructor
             {
                 Name="Taha Huissen",
                 ShortBio=" he is an instructor ...."
             }
                   
            );
            var Course = await _courseRepository.InsertAsync(
               new Course
               {
                   InstructorId = Instructor.Id,
                   Name = "Java",

                   StartDate = new DateTime(2022, 7, 8),
                   Price = 2000.84f
               }
               );
            await _studentRepository.InsertAsync(
               new Student
               {
                  
                   Name = "samar",
                   Age=24,
                   Address="minia-matay",
                   CourseId=Course.Id
                  

                   
               }
               );


            await _courseRepository.InsertAsync(
               new Course
               {
                   InstructorId = Instructor.Id,
                   Name = "C#",
                  
                   StartDate = new DateTime(2022, 6, 8),
                   Price = 1000.84f
               },

               autoSave: true
           );

        }
    }
}
