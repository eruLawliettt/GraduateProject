using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AddingEntities
{
    public class DisciplineCreationModel : PageModel
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplineCreationModel(IDisciplineService disciplineService)
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
            var discipline = new Discipline()
            {
                IsDeleted = false,
                IsHidden = false,
                Code = Input.Code,
                Name = Input.Name,
                Description = Input.Description
            };

            await _disciplineService.CreateDisciplineAsync(discipline);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Код дисциплины")]
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
