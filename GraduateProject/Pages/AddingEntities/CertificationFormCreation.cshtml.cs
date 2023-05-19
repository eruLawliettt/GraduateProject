using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AddingEntities
{
    public class CertificationFormCreationModel : PageModel
    {
        private readonly ICertificationFormService _certificationFormService;

        public CertificationFormCreationModel(ICertificationFormService certificationFormService)
        {
            _certificationFormService = certificationFormService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var certificationForm = new CertificationForm()
            {
                IsDeleted = false,
                IsHidden = false,              
                Name = Input.Name,
                Description = Input.Description,
            };

            await _certificationFormService.CreateCertificationFormAsync(certificationForm);

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
