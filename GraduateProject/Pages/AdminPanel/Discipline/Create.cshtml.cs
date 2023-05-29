using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AdminPanel.Discipline
{
    public class CreateModel : PageModel
    {
        private readonly IDisciplineService _disciplineService;

        public CreateModel(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var discipline = new Entities.Curriculum.Discipline()
            {
                Code = Input.Code,
                Name = Input.Name,
                Description = Input.Description,
            };

            await _disciplineService.CreateDisciplineAsync(discipline);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Код")]
            public string Code { get; set; }

            [Required]
            [Display(Name = "Название")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Описание")]
            public string Description { get; set; }
        }
    }
}
