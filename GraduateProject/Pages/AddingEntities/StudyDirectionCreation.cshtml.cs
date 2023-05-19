using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GraduateProject.Pages.AddingEntities
{
    public class StudyDirectionCreationModel : PageModel
    {
        private readonly IStudyDirectionService _studyDirectionService;


        public StudyDirectionCreationModel(IStudyDirectionService studyDirectionService)
        {
            _studyDirectionService = studyDirectionService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var studyDirection = new StudyDirection()
            {
                IsDeleted = false,
                IsHidden = false,
                Code = Input.Code,
                Name = Input.Name,
                Description = Input.Description,
                Period = Input.Period
            };

            await _studyDirectionService.CreateStudyDirectionAsync(studyDirection);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Код направления")]
            public string Code { get; set; }

            [Required]
            [Display(Name = "Название")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Описание")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Срок обучения в месяцах")]
            public int Period { get; set; }
        }
    }
}
