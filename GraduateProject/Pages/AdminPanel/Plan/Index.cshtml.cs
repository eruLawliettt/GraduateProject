using GraduateProject.Data;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.Plan
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlanService _planService;
        public List<Entities.Curriculum.Plan> Plans { get; set; }

        public IndexModel(ApplicationDbContext context, IPlanService planService)
        {
            _context = context; ;
            _planService = planService;
            Plans = _planService.GetAllPlans();
        }

        public void OnGet()
        {
        }
    }
}
