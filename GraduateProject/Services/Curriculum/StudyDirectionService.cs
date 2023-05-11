using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class StudyDirectionService : IStudyDirectionService
    {
        private readonly ApplicationDbContext _context;

        public StudyDirectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateStudyDirectionAsync(StudyDirection studyDirection)
        {
            _context.StudyDirections.Add(studyDirection);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateStudyDirectionAsync(StudyDirection studyDirection)
        {
            _context.StudyDirections.Update(studyDirection);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeleteStudyDirectionAsync(Guid studyDirectionId)
        {
            var studyDirection = _context.StudyDirections
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == studyDirectionId));

            if (studyDirection == null)
                return default;

            studyDirection.IsDeleted = true;

            return await UpdateStudyDirectionAsync(studyDirection);
        }

        public List<StudyDirection> GetAllStudyDirections()
        {
            return _context.StudyDirections
                .Where(p => p.IsDeleted != true)
                .ToList();
        }

        public StudyDirection GetStudyDirectionById(Guid studyDirectionId)
        {
            return _context.StudyDirections
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == studyDirectionId))
                ?? throw new InvalidOperationException("StudyDirection by id was not found.");
        }
    }
}
