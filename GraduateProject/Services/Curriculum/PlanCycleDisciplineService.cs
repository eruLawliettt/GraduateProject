using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class PlanCycleDisciplineService : IPlanCycleDisciplineService
    {
        private readonly ApplicationDbContext _context;

        public PlanCycleDisciplineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlanCycleDisciplineAsync(PlanCycleDiscipline planCycleDiscipline)
        {
            _context.PlanCycleDisciplines.Add(planCycleDiscipline);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePlanCycleDisciplineAsync(PlanCycleDiscipline planCycleDiscipline)
        {
            _context.PlanCycleDisciplines.Update(planCycleDiscipline);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление не логическое
        /// </summary>
        public async Task<int> DeletePlanCycleDisciplineAsync(Guid planCycleDisciplineId)
        {
            var planCycleDiscipline = _context.PlanCycleDisciplines
                .FirstOrDefault(p => p.Id == planCycleDisciplineId);

            if (planCycleDiscipline == null)
                return default;

            _context.PlanCycleDisciplines.Remove(planCycleDiscipline);

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Нет проверки на IsDeleted
        /// </summary>
        public List<PlanCycleDiscipline> GetAllPlanCycleDisciplines()
        {
            return _context.PlanCycleDisciplines
                .ToList();
        }

        /// <summary>
        /// Нет проверки на IsDeleted
        /// </summary>
        public PlanCycleDiscipline GetPlanCycleDisciplineById(Guid planCycleDisciplineId)
        {
            return _context.PlanCycleDisciplines
                .FirstOrDefault(c => c.Id == planCycleDisciplineId)
                ?? throw new InvalidOperationException("PlanCycleDiscipline by id was not found.");
        }
    }
}
