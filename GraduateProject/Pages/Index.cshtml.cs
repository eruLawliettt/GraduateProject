using GraduateProject.Data;
using GraduateProject.Entities.Identity;
using GraduateProject.Entities.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduateProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public bool IsUserStudent(Guid id)
        {
            return _context.Students.Any(x => x.UserId == id);
        }

        public Student GetStudentByUserId(Guid id)
        {
            return _context.Students
                .Include(s => s.Group)
                .ThenInclude(g => g.Plan)
                .ThenInclude(p => p.Semesters)
                .FirstOrDefault(s => s.UserId == id);
        }

        public void OnGet()
        {

        }
    }
}