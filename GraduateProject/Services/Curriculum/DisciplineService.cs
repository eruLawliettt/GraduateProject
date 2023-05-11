using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class DisciplineService : IDisciplineService
    {
        private readonly ApplicationDbContext _context;

        public DisciplineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateDisciplineAsync(Discipline discipline)
        {
            _context.Disciplines.Add(discipline);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateDisciplineAsync(Discipline discipline)
        {
            _context.Disciplines.Update(discipline);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeleteDisciplineAsync(Guid disciplineId)
        {
            var discipline = _context.Disciplines
                .FirstOrDefault(d => (d.IsDeleted != true) && (d.Id == disciplineId));

            if (discipline == null)
                return default;

            discipline.IsDeleted = true;

            return await UpdateDisciplineAsync(discipline);
        }

        public List<Discipline> GetAllDisciplines()
        {
            return _context.Disciplines
                .Where(d => d.IsDeleted != true)
                .ToList();
        }

        public Discipline GetDisciplineById(Guid disciplineId)
        {
            return _context.Disciplines
               .FirstOrDefault(d => (d.IsDeleted != true) && (d.Id == disciplineId))
               ?? throw new InvalidOperationException("Discipline by id was not found.");
        }
    }
}
