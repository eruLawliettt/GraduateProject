using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AdminPanel.Employee
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        public List<string> Genders { get; private set; } = new List<string>()
        { "�������", "�������" };
        public List<Entities.Subject.Position> Positions { get; }

        public CreateModel(IEmployeeService employeeService, IPositionService positionService)
        {
            _employeeService = employeeService;
            _positionService = positionService;
            Positions = _positionService.GetAllPositions();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var gender = false;
            if (Input.Gender == "�������")
                gender = true;

            var employee = new Entities.Subject.Employee()
            {
                FirstName = Input.FirstName,
                MiddleName = Input.MiddleName,
                LastName = Input.LastName,
                DateOfBirth = Input.DateOfBirth,
                Gender = gender,
            };

            await _employeeService.CreateEmployeeAsync(employee);

            if (Input.Positions.Count > 0)
            {
                foreach (var positionId in Input.Positions)
                {
                    var employeePosition = new EmployeePosition()
                    {
                        EmployeeId = employee.Id,
                        PositionId = Guid.Parse(positionId),
                    };

                    await _employeeService.CreateEmployeePositionAsync(employeePosition);
                }
            }
                     
            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "���")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "��������")]
            public string MiddleName { get; set; }

            [Required]
            [Display(Name = "�������")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "���� ��������")]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [Display(Name = "���")]
            public string Gender { get; set; }

            [Required]
            [Display(Name = "���������")]
            public List<string> Positions { get; set; }
        }
    }
}
