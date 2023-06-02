using GraduateProject.Data;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraduateProject.Services.Subject
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<int> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<int> DeleteStudentAsync(Guid studentId)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == studentId);

            if (student == null)
                return default;

            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students
                .Include(s => s.Group)
                .ToList();
        }

        public Student GetStudentById(Guid studentId)
        {
            return _context.Students
                .Include(s => s.ReportMarks)
                .ThenInclude(r => r.Discipline)
                .Include(s => s.ReportMarks)
                .ThenInclude(r => r.Report)
               .FirstOrDefault(s => s.Id == studentId)
               ?? throw new InvalidOperationException("Student by id was not found.");
        }
    }
}
