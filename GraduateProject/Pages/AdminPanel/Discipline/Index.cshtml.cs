using GraduateProject.Data;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.Discipline
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IDisciplineService _disciplineService;
        public List<Entities.Curriculum.Discipline> Disciplines { get; set; }

        public IndexModel(ApplicationDbContext context, IDisciplineService disciplineService)
        {
            _context = context; ;
            _disciplineService = disciplineService;
            Disciplines = _disciplineService.GetAllDisciplines();
        }

        public void OnGet()
        {
        }
    }
}
