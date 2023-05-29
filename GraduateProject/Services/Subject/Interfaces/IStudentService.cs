using GraduateProject.Entities.Subject;

namespace GraduateProject.Services.Subject.Interfaces
{
    public interface IStudentService
    {
        Task<int> CreateStudentAsync(Student student);
        Task<int> UpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(Guid studentId);

        List<Student> GetAllStudents();
        Student GetStudentById(Guid studentId);
    }
}
