using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AddingEntities
{
    public class CycleCreationModel : PageModel
    {
        private readonly ICycleService _cycleService;

        public CycleCreationModel(ICycleService cycleService)
        {
            _cycleService = cycleService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cycle = new Cycle()
            {
                IsDeleted = false,
                IsHidden = false,
                Code = Input.Code,
                Name = Input.Name,
            };

            await _cycleService.CreateCycleAsync(cycle);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Код Цикла")]
            public string Code { get; set; }

            [Required]
            [Display(Name = "Название")]
            public string Name { get; set; }
        }
    }
}
