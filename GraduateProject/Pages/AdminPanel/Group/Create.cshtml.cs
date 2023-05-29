using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AdminPanel.Group
{
    public class CreateModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IEmployeeService _employeeService;
        private readonly IStudyDirectionService _studyDirectionService;
        private readonly IPositionService _positionService;

        public List<Entities.Subject.Employee> Employees { get; }
        public List<Entities.Curriculum.StudyDirection> StudyDirections { get; }
        public List<Entities.Subject.Position> Positions { get; set; }

        public CreateModel(IGroupService groupService, IEmployeeService employeeService, 
            IStudyDirectionService studyDirectionService, IPositionService positionService)
        {
            _groupService = groupService;
            _employeeService = employeeService;
            _studyDirectionService = studyDirectionService;
            _positionService = positionService;
            Employees = _employeeService.GetAllEmployees();
            StudyDirections = _studyDirectionService.GetAllStudyDirections();
            Positions = _positionService.GetAllPositions();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var group = new Entities.Subject.Group()
            {
                IsDeleted = false,
                IsHidden = false,
                Name = Input.Name,
                EntryDate = Input.EntryDate,
                StudyDirectionId = Guid.Parse(Input.StudyDirectionId),
                SupervisorId = Guid.Parse(Input.SupervisorId)
            };
            
            var employee = _employeeService.GetEmployeeById(Guid.Parse(Input.SupervisorId));
            var curator = Positions.FirstOrDefault(p => p.Name == "Куратор");

            if (curator == default)
            {
                curator = new Entities.Subject.Position()
                {
                    Name = "Куратор",
                    Description = "Куратор владеет группами"
                };
                await _positionService.CreatePositionAsync(curator);
            }

            if (employee.EmployeePositions.FirstOrDefault(p => p.PositionId == curator.Id) == default)
            {
                var employeePosition = new Entities.Subject.EmployeePosition()
                {
                    EmployeeId = employee.Id,
                    PositionId = curator.Id
                };

                await _employeeService.CreateEmployeePositionAsync(employeePosition);
            }
                       
            await _groupService.CreateGroupAsync(group);

            return RedirectToPage("Index");
        }
        
        public class InputModel
        {
            [Required]
            [Display(Name = "Название")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Дата поступления")]
            public DateTime EntryDate { get; set; }

            [Required]
            [Display(Name = "Направление")]
            public string StudyDirectionId { get; set; }

            [Required]
            [Display(Name = "Куратор")]
            public string SupervisorId { get; set; }
        }
    }
}
