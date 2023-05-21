using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GraduateProject.Pages.AddingEntities
{
    public class ProfessionalModuleCreationModel : PageModel
    {
        private readonly IProfessionalModuleService _professionalModuleService;
        private readonly ICertificationFormService _certificationFormService;
        public List<CertificationForm> CertificationForms { get; set; }

        public ProfessionalModuleCreationModel(IProfessionalModuleService professionalModuleService,
            ICertificationFormService certificationFormService)
        {
            _professionalModuleService = professionalModuleService;
            _certificationFormService = certificationFormService;
            CertificationForms = _certificationFormService.GetAllCertificationForms();    
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {


            var professionalModule = new ProfessionalModule()
            {
                IsDeleted = false,
                IsHidden = false,
                Code = Input.Code,
                Name = Input.Name,
                Description = Input.Description,
                CertificationHours = Input.CertificationHours,
                CertificationFormId = Guid.Parse(Input.CertificationFormId)
            };

            await _professionalModuleService.CreateProfessionalModuleAsync(professionalModule);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Код модуля")]
            public string Code { get; set; }

            [Required]
            [Display(Name = "Название")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Описание")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Аттестационное количество часов")]
            public int CertificationHours { get; set; }

            [Required]
            [Display(Name = "Форма аттестации")]
            public string CertificationFormId { get; set; }
        }
    }
}
