using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Report.Interfaces;
using GraduateProject.Services.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GraduateProject.Pages.Mark.Groups.Disciplines
{
    public class IndexModel : PageModel
    {
        private readonly IDisciplineService _disciplineService;
        private readonly IGroupService _groupService;
        private readonly IProgressReportService _progressReportService;


        [BindProperty(SupportsGet = true)]
        public string DisciplineId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GroupId { get; set; }

        
        public Discipline Discipline { get; set; }
        public Group Group { get; set; }

        public List<Semester> Semesters { get; set; }
        public List<Student> Students { get; set; }

        public List<ProgressReport> Reports { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public IndexModel(IDisciplineService disciplineService, 
            IGroupService groupService,
            IProgressReportService progressReportService)
        {
            _disciplineService = disciplineService;
            _groupService = groupService;
            _progressReportService = progressReportService;
            Reports = _progressReportService.GetAllProgressReports();

            
        }

        public void OnGet()
        {
            Discipline = _disciplineService.GetDisciplineById(Guid.Parse(DisciplineId));
            Group = _groupService.GetGroupById(Guid.Parse(GroupId));
            Semesters = Group.Plan.Semesters.ToList();
            Students = Group.Students.ToList();

        }

        public async Task<IActionResult> OnPost()
        {                        
            OnGet();

            var report = new ProgressReport();
            Reports ??= new();
           
            report = Reports
                   .FirstOrDefault(p => (p.GroupId == Guid.Parse(GroupId))
                   && (p.SemesterId == Guid.Parse(Input.SemesterId)));
                         
            if (report == default)
            {
                ProgressReport progressReport = new ()
                {
                    Number = Group.Name + DateTime.Now.Day.ToString() + Group.Name.Length,
                    Date = DateTime.Now,
                    GroupId = Group.Id,
                    SemesterId = Guid.Parse(Input.SemesterId)
                };
                report = progressReport;
                await _progressReportService.CreateProgressReportAsync(report);
            }

            int i = 0;
            foreach (var student in Students)
            {
                var reportMark = new ReportMark
                {
                    ReportId = report.Id,
                    DisciplineId = Discipline.Id,
                    StudentId = student.Id,
                    Mark = Input.Marks[i]                   
                };
                i++;

                await _progressReportService.CreateReportMarkAsync(reportMark);
            }                            
            return RedirectToPage($"../../../Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Семестр")]
            public string SemesterId { get; set; }

            [Required]
            [Display(Name = "Оценки")]
            public List<string> Marks { get; set; } = new();
        }
    }
}
