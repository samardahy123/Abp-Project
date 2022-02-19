using CoursesAppMVC.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace CoursesAppMVC.Web.Pages.Students
{
    public class CreateModalModel : CoursesAppMVCPageModel
    {
        [BindProperty]
        public CreateStudentViewModel Student { get; set; }
        public List<SelectListItem> Courses { get; set; }


        private readonly IStudentAppService _studentAppService;

        public CreateModalModel(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public async void OnGet()
        {
            Student = new CreateStudentViewModel();
            var StudentCourse = await _studentAppService.GetStudentCourseAsync();
            Courses = StudentCourse.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _studentAppService.CreateAsync(
                ObjectMapper.Map<CreateStudentViewModel, CreateUpdateStudentDto>(Student)
                );
            return NoContent();

        }
        public class CreateStudentViewModel
        {
            [SelectItems(nameof(Courses))]
            [DisplayName("Course")]
            public System.Guid CourseId { get; set; }

            [Required]
           
            public string Name { get; set; }

            [Required]
            public string Address { get; set; }

            
            public int Age { get; set; }

           

        }
    }
}
