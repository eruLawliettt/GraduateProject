using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Report.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Report.Groups.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;

        [BindProperty(SupportsGet = true)]
        public string StudentId { get; set; }

        public Student Student { get; set; }

        public IndexModel(IStudentService studentService,
            IProgressReportService progressReportService)
        {
            _studentService = studentService;
        }

        public async Task OnGet()
        {
            Student = _studentService.GetStudentById(Guid.Parse(StudentId));

        }
    }
}
