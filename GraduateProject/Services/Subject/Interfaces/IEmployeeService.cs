using GraduateProject.Entities.Subject;

namespace GraduateProject.Services.Subject.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(Guid employeeId);
        Task<int> CreateEmployeePositionAsync(EmployeePosition employeePosition);

        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid employeeId);
    }
}
