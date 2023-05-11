using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class SemesterService : ISemesterService
    {
        private readonly ApplicationDbContext _context;

        public SemesterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSemesterAsync(Semester semester)
        {
            _context.Semesters.Add(semester);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSemesterAsync(Semester semester)
        {
            _context.Semesters.Update(semester);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeleteSemesterAsync(Guid semesterId)
        {
            var semester = _context.Semesters
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == semesterId));

            if (semester == null)
                return default;

            semester.IsDeleted = true;

            return await UpdateSemesterAsync(semester);
        }

        public List<Semester> GetAllSemesters()
        {
            return _context.Semesters
                .Where(p => p.IsDeleted != true)
                .ToList();
        }

        public Semester GetSemesterById(Guid semesterId)
        {
            return _context.Semesters
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == semesterId))
                ?? throw new InvalidOperationException("Semester by id was not found.");
        }
    }
}
