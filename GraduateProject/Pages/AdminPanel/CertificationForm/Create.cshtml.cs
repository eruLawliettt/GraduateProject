using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AdminPanel.CertificationForm
{
    public class CreateModel : PageModel
    {
        private readonly ICertificationFormService _certificationFomService;

        public CreateModel(ICertificationFormService certificationFomService)
        {
            _certificationFomService = certificationFomService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var certificationForm = new Entities.Curriculum.CertificationForm()
            {
                Name = Input.Name,
                Description = Input.Description,
            };

            await _certificationFomService.CreateCertificationFormAsync(certificationForm);

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
