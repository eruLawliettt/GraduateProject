using GraduateProject.Data;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.Employee
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeService _employeeService;
        public List<Entities.Subject.Employee> Employees { get; set; }

        public IndexModel(ApplicationDbContext context, IEmployeeService employeeService)
        {
            _context = context; ;
            _employeeService = employeeService;
            Employees = _employeeService.GetAllEmployees();
        }
    }
}
