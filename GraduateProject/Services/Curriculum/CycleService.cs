using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class CycleService : ICycleService
    {
        private readonly ApplicationDbContext _context;

        public CycleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCycleAsync(Cycle cycle)
        {
            _context.Cycles.Add(cycle);
            return await _context.SaveChangesAsync(); 
        }

        public async Task<int> UpdateCycleAsync(Cycle cycle)
        {
            _context.Cycles.Update(cycle);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeleteCycleAsync(Guid cycleId)
        {
            var cycle = _context.Cycles
                .FirstOrDefault(c => (c.IsDeleted != true) && (c.Id == cycleId));

            if (cycle == null)
                return default;

            cycle.IsDeleted = true;

            return await UpdateCycleAsync(cycle);
        }

        public List<Cycle> GetAllCycles()
        {
            return _context.Cycles
                .Where(c => c.IsDeleted != true)
                .ToList();
        }

        public Cycle GetCycleById(Guid cycleId)
        {
            return _context.Cycles
                .FirstOrDefault(c => (c.IsDeleted != true) && (c.Id == cycleId))
                ?? throw new InvalidOperationException("Cycle by id was not found.");
        }

        
    }
}
