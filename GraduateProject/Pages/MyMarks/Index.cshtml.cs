using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Report.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.MyMarks
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly ISemesterService _semesterService;

        public Student Student { get; set; }
        public Semester Semester { get; set; }

        public IndexModel(IStudentService studentService, ISemesterService semesterService)
        {
            _studentService = studentService;
            _semesterService = semesterService;
        }

        [BindProperty(SupportsGet = true)]
        public string StudentId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SemesterId { get; set; }

        public void OnGet()
        {
            Student = _studentService.GetStudentById(Guid.Parse(StudentId));
            Semester = _semesterService.GetSemesterById(Guid.Parse(SemesterId));
        }
    }
}
