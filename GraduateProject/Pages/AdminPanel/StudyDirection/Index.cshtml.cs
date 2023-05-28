using GraduateProject.Data;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.StudyDirection
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudyDirectionService _studyDirectionService;
        public List<Entities.Curriculum.StudyDirection> StudyDirections { get; set; }

        public IndexModel(ApplicationDbContext context, IStudyDirectionService studyDirectionService)
        {
            _context = context; ;
            _studyDirectionService = studyDirectionService;
            StudyDirections = _studyDirectionService.GetAllStudyDirections();
        }

        public void OnGet()
        {
        }
    }
}
