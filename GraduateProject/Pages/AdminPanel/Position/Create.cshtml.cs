using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AdminPanel.Position
{
    public class CreateModel : PageModel
    {
        private readonly IPositionService _positionService;

        public CreateModel(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var position = new Entities.Subject.Position()
            {
                Name = Input.Name,
                Description = Input.Description,
            };

            await _positionService.CreatePositionAsync(position);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Название")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Описание")]
            public string Description { get; set; }
        }
    }
}
