using CoursesAppMVC.Courses;
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

namespace CoursesAppMVC.Web.Pages.Courses
{
    public class EditModalModel : CoursesAppMVCPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public EditCourseViewModel Course { get; set; }
        public List<SelectListItem> Instructors { get; set; }


        private readonly ICourseAppService _courseAppService;

        public EditModalModel(ICourseAppService CourseAppService)
        {
            _courseAppService = CourseAppService;
        }

        public async Task OnGetAsync()


        {
            var courseDto = await _courseAppService.GetAsync(Id);
            Course = ObjectMapper.Map<CourseDto, EditCourseViewModel>(courseDto);

            var InstrLookup = await _courseAppService.GetInstructorLookupAsync();
            Instructors = InstrLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

          
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseAppService.UpdateAsync(Course.Id, ObjectMapper.Map<EditCourseViewModel, CreateUpdateCourseDto>(Course)
         );
            return NoContent();
        }
        public class EditCourseViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Instructors))]
            [DisplayName("Instructor")]
            public Guid InstructorId { get; set; }

            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            [Required]
            public String Description { get; set; } 

            [Required]
            [DataType(DataType.Date)]
            public DateTime StartSate { get; set; } = DateTime.Now;

            [Required]
            public float Price { get; set; }
        }
    }
}