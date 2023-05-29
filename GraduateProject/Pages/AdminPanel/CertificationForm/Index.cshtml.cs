using GraduateProject.Data;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.CertificationForm
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ICertificationFormService _certificationFomService;
        public List<Entities.Curriculum.CertificationForm> CertificationForms { get; set; }

        public IndexModel(ApplicationDbContext context, ICertificationFormService certificationFomService)
        {
            _context = context; ;
            _certificationFomService = certificationFomService;
            CertificationForms = _certificationFomService.GetAllCertificationForms();
        }

        public void OnGet()
        {
        }
    }
}
