using CoursesAppMVC.Instructors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace CoursesAppMVC.Web.Pages.Instructors
{
    public class EditModalModel : CoursesAppMVCPageModel

    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateInstructorDto Instructor { get; set; }

        private readonly IInstructorAppService _instructorAppService;

        public EditModalModel(IInstructorAppService instructorAppService)
        {
            _instructorAppService = instructorAppService;
        }

        public async Task OnGetAsync()
        {
            var instDto = await _instructorAppService.GetAsync(Id);
            Instructor = ObjectMapper.Map<InstructorDto, CreateUpdateInstructorDto>(instDto);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _instructorAppService.UpdateAsync(Id,Instructor);
            return NoContent();
        }


    }
}

