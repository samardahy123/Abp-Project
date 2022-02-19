using CoursesAppMVC.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace CoursesAppMVC.Web.Pages.Students
{
    public class EditModalModel : CoursesAppMVCPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public EditStudentViewModel Student { get; set; }
        public List<SelectListItem> Courses { get; set; }


        private readonly IStudentAppService _studentAppService;

        public EditModalModel(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public async Task OnGetAsync()


        {
            try
            {
                var studentDto = await _studentAppService.GetAsync(Id);
                Student = ObjectMapper.Map<StudentDto, EditStudentViewModel>(studentDto);

                var InstrLookup = await _studentAppService.GetStudentCourseAsync();
                Courses = InstrLookup.Items
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _studentAppService.UpdateAsync(Student.Id, ObjectMapper.Map<EditStudentViewModel, CreateUpdateStudentDto>(Student)
         );
            return NoContent();
        }
        public class EditStudentViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Courses))]
            [DisplayName("Course")]
            public Guid CourseId { get; set; }

            [Required]

            public string Name { get; set; }

            [Required]
            public string Address { get; set; }


            public int Age { get; set; }
        }
    }
}