using AutoMapper;

using CoursesAppMVC.Models;
using CoursesAppMVC.Instructors;
using CoursesAppMVC.Courses;
using CoursesAppMVC.Students;

namespace CoursesAppMVC;

public class CoursesAppMVCApplicationAutoMapperProfile : Profile
{
    public CoursesAppMVCApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CoursesAppMVC.Models.Course, CourseDto>();
        CreateMap<CreateUpdateCourseDto, CoursesAppMVC.Models.Course>();
        CreateMap<Instructor, InstructorLookUpDto>();
        CreateMap<CourseDto, CreateUpdateCourseDto>();
        
        CreateMap<CoursesAppMVC.Models.Course, StudentCourseDto>();
        CreateMap<CoursesAppMVC.Models.Student, StudentCourseDto>();

        CreateMap<Instructor, InstructorDto>();
        CreateMap<CreateUpdateInstructorDto, Instructor>();
        CreateMap<InstructorDto,CreateUpdateInstructorDto>();

        CreateMap<CoursesAppMVC.Models.Student, StudentDto>();
        CreateMap<CreateUpdateStudentDto, CoursesAppMVC.Models.Student>();
         CreateMap<StudentDto, CreateUpdateStudentDto>();
       
        //CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, CreateUpdateCourseDto>();
        //CreateMap<CourseDto, Pages.Courses.EditModalModel.EditCourseViewModel>();
        //CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, CreateUpdateCourseDto>();
        //CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, InstructorDto>();

    }

}
