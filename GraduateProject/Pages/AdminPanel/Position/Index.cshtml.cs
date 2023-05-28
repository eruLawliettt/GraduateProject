using GraduateProject.Data;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.Position
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IPositionService _positionService;
        public List<Entities.Subject.Position> Positions { get; set; }

        public IndexModel(ApplicationDbContext context, IPositionService positionService)
        {
            _context = context; ;
            _positionService = positionService;
            Positions = _positionService.GetAllPositions();
        }

        public void OnGet()
        {
        }
    }
}
