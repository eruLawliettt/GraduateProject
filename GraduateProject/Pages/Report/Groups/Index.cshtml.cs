using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Report.Groups
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IDisciplineService _disciplineService;
        private readonly ApplicationDbContext _context;    
        

        [BindProperty(SupportsGet = true)]
        public string GroupId { get; set; }

        public List<Discipline> Disciplines { get; set; }   
        public List<Semester> Semesters { get; set; }

        public Group Group { get; set; }

        public IndexModel(IGroupService groupService,
            IDisciplineService disciplineService)
        {
            _groupService = groupService;
            _disciplineService = disciplineService;
        }

        public async Task OnGet()
        {
            Group = _groupService.GetGroupById(Guid.Parse(GroupId));
            Disciplines = _disciplineService.GetAllDisciplines();

            Semesters = Group.Plan.Semesters.ToList();           
        }


    }
}
