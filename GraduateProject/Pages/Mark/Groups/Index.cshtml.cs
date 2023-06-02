using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum.Interfaces;
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

        public List<Plan> Plans { get; set; }
        public List<Discipline> Disciplines { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GroupId { get; set; }

        public Group Group { get; set; }

        public IndexModel(IGroupService groupService,
            IPlanService planService,
            ISemesterService semesterService,
            IDisciplineService disciplineService)
        {
            _groupService = groupService;
            _planService = planService;
            _semesterService = semesterService;
            _disciplineService = disciplineService;
            Plans = _planService.GetAllPlans();
            Disciplines = _disciplineService.GetAllDisciplines();                                           
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
                else
                    planExists = false;
            }

            if (planExists == false)
            {
                _planService.CreatePlanAsync(plan);

                for (int i = 1; i <= 8; i++)
                {
                    var semester = new Semester()
                    {
                        IsDeleted = false,
                        IsHidden = false,
                        Number = i,
                        PlanId = plan.Id
                    };
                    _semesterService.CreateSemesterAsync(semester);
                }
            }
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
            [Display(Name = "Оценка")]
            public string Mark { get; set; }

        }

    }
}
