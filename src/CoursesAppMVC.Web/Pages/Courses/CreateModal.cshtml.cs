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
    public class CreateModalModel : CoursesAppMVCPageModel
    {
        [BindProperty]
        public CreateCourseViewModel Course { get; set; }
        public List<SelectListItem> Instructors { get; set; }


        private readonly ICourseAppService _courseAppService;

        public CreateModalModel(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        public async void OnGet()
        {
            Course = new CreateCourseViewModel();
            var InstLookup = await _courseAppService.GetInstructorLookupAsync();
            Instructors = InstLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseAppService.CreateAsync(
                ObjectMapper.Map<CreateCourseViewModel, CreateUpdateCourseDto>(Course)
                );
            return NoContent();
            
        }
        public class CreateCourseViewModel
        {
            [SelectItems(nameof(Instructors))]
            [DisplayName("Insructor")]
            public Guid InstructorId { get; set; }

            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            [Required]
            public string Description { get; set; } 

            [Required]
            [DataType(DataType.Date)]
            public DateTime StartDateDate { get; set; } = DateTime.Now;

            [Required]
            public float Price { get; set; }
        }
    }
}
