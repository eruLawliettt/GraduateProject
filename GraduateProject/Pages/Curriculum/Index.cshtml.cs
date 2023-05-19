using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Curriculum
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlanService _planService;
        public List<Plan> Plans { get; set; }

        public void OnGet()
        {
        }

        public IndexModel(ApplicationDbContext context, IPlanService planService)
        {
            _context = context;
            _planService = planService;
            Plans = _planService.GetAllPlans();
        }
    }
}
