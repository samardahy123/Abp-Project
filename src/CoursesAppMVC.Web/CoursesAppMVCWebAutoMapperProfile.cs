using AutoMapper;
using CoursesAppMVC.Courses;
using CoursesAppMVC.Students;

namespace CoursesAppMVC.Web;

public class CoursesAppMVCWebAutoMapperProfile : Profile
{
    public CoursesAppMVCWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, CreateUpdateCourseDto>();
        CreateMap<CourseDto, Pages.Courses.EditModalModel.EditCourseViewModel>();
        CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, CreateUpdateCourseDto>();

        CreateMap<Pages.Students.CreateModalModel.CreateStudentViewModel, CreateUpdateStudentDto>();
        CreateMap<StudentDto, Pages.Students.EditModalModel.EditStudentViewModel>();
        CreateMap<Pages.Students.EditModalModel.EditStudentViewModel, CreateUpdateStudentDto>();
       
    }
}
