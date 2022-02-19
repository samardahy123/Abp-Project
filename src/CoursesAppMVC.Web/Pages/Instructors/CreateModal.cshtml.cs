using AutoMapper;
using CoursesAppMVC.Instructors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace CoursesAppMVC.Web.Pages.Instructors
{
    public class CreateModalModel : CoursesAppMVCPageModel
    {
        [BindProperty]
        public CreateUpdateInstructorDto Instructor { get; set; }

        private readonly IInstructorAppService _instructorAppService;

        public CreateModalModel(IInstructorAppService instructorAppService)
        {
            _instructorAppService = instructorAppService;
        }

        public void OnGet()
        {
            Instructor = new CreateUpdateInstructorDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _instructorAppService.CreateAsync(Instructor);
            return NoContent();
        }

       
    }
}

