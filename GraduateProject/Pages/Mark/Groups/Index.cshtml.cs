using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Report.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace GraduateProject.Pages.Mark.Groups
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IPlanService _planService;
        private readonly ISemesterService _semesterService;
        private readonly IDisciplineService _disciplineService;
        private readonly IProgressReportService _progressReportService;

        public List<Plan> Plans { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<ProgressReport> ProgressReports { get; set; }


        [BindProperty(SupportsGet = true)]
        public string GroupId { get; set; }

        public Group Group { get; set; }

        public IndexModel(IGroupService groupService,
            IPlanService planService,
            ISemesterService semesterService,
            IDisciplineService disciplineService,
            IProgressReportService progressReportService)
        {
            _groupService = groupService;
            _planService = planService;
            _semesterService = semesterService;
            _disciplineService = disciplineService;
            _progressReportService = progressReportService;
            Plans = _planService.GetAllPlans();
            Disciplines = _disciplineService.GetAllDisciplines();   
            ProgressReports = _progressReportService.GetAllProgressReports();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task OnGet()
        {
            Group = _groupService.GetGroupById(Guid.Parse(GroupId));

            var plan = new Plan()
            {
                IsDeleted = false,
                IsHidden = false,
                GroupId = Guid.Parse(GroupId),
            };

            bool planExists = false;
            foreach (var item in Plans)
            {
                if (plan.GroupId == item.GroupId)
                    planExists = true;
                
            }

            if (planExists == false)
            {
                await _planService.CreatePlanAsync(plan);

                for (int i = 1; i <= 8; i++)
                {
                    var semester = new Semester()
                    {
                        IsDeleted = false,
                        IsHidden = false,
                        Number = i,
                        PlanId = plan.Id
                    };

                    await _semesterService.CreateSemesterAsync(semester);                  
                }
            }

            Group = _groupService.GetGroupById(Guid.Parse(GroupId));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Group = _groupService.GetGroupById(Guid.Parse(GroupId));

            var report = ProgressReports
                .FirstOrDefault(p => (p.GroupId == Guid.Parse(GroupId)) 
                && (p.SemesterId == Guid.Parse(Input.SemesterId)));
            if (report == default)
            {
                var progressReport = new ProgressReport()
                {
                    Number = Group.Name + DateTime.Now.Day.ToString() + Group.Name.Length,
                    Date = DateTime.Now,
                    GroupId = Group.Id,
                    SemesterId = Guid.Parse(Input.SemesterId)
                };

                report = progressReport;
                await _progressReportService.CreateProgressReportAsync(progressReport);
            }

            var mark = new ReportMark()
            {
                ReportId = report.Id,
                DisciplineId = Guid.Parse(Input.DisciplineId),
                StudentId = Guid.Parse(Input.StudentId),
                Mark = Input.Mark
            };

            await _progressReportService.CreateReportMarkAsync(mark);

            
            return RedirectToPage("../Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Студент")]
            public string StudentId { get; set; }

            [Required]
            [Display(Name = "Дисциплина")]
            public string DisciplineId { get; set; }

            [Required]
            [Display(Name = "Семестр")]
            public string SemesterId { get; set; }

            [Required]
            [Display(Name = "Оценка (2-5, Зачёт, Незачёт)")]
            public string Mark { get; set; }

        }

    }
}
