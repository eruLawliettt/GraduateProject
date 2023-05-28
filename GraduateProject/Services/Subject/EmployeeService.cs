using GraduateProject.Data;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraduateProject.Services.Subject
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = _context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
                return default;

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> CreateEmployeePositionAsync(EmployeePosition employeePosition)
        {
            _context.EmployeePositions.Add(employeePosition);
            return await _context.SaveChangesAsync();
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees
                .Include(e => e.EmployeePositions)
                .ThenInclude(ep => ep.Position)
                .ToList();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return _context.Employees
                .FirstOrDefault(e => e.Id == employeeId)
                ?? throw new InvalidOperationException("Employee by id was not found.");
        }

        
    }
}
