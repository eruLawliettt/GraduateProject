using GraduateProject.Data;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.Student
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentService _studentService;
        public List<Entities.Subject.Student> Students { get; set; }

        public IndexModel(ApplicationDbContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
            Students = _studentService.GetAllStudents();
        }
    }
}
