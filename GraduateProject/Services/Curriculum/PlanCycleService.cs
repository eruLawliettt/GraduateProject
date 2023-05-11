using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class PlanCycleService : IPlanCycleService
    {
        private readonly ApplicationDbContext _context;

        public PlanCycleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlanCycleAsync(PlanCycle planCycle)
        {
            _context.PlanCycles.Add(planCycle);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePlanCycleAsync(PlanCycle planCycle)
        {
            _context.PlanCycles.Update(planCycle);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление не логическое
        /// </summary>
        public async Task<int> DeletePlanCycleAsync(Guid planCycleId)
        {
            var planCycle = _context.PlanCycles
                .FirstOrDefault(p => p.Id == planCycleId);

            if (planCycle == null)
                return default;

            _context.PlanCycles.Remove(planCycle);

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Нет проверки на IsDeleted
        /// </summary>
        public List<PlanCycle> GetAllPlanCycles()
        {
            return _context.PlanCycles
                .ToList();
        }

        /// <summary>
        /// Нет проверки на IsDeleted
        /// </summary>
        public PlanCycle GetPlanCycleById(Guid planCycleId)
        {
            return _context.PlanCycles
                .FirstOrDefault(c => c.Id == planCycleId)
                ?? throw new InvalidOperationException("PlanCycle by id was not found.");
        }
    }
}
