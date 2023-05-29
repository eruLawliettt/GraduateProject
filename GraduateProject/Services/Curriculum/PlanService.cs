using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraduateProject.Services.Curriculum
{
    public class PlanService : IPlanService
    {
        private readonly ApplicationDbContext _context;

        public PlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlanAsync(Plan plan)
        {
            _context.Plans.Add(plan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePlanAsync(Plan plan)
        {
            _context.Plans.Update(plan);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeletePlanAsync(Guid planId)
        {
            var plan = _context.Plans
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == planId));

            if (plan == null)
                return default;

            plan.IsDeleted = true;

            return await UpdatePlanAsync(plan);
        }

        public List<Plan> GetAllPlans()
        {
            return _context.Plans
                .Where(p => p.IsDeleted != true)
                .Include(p => p.Group)
                .ThenInclude(g => g.StudyDirection)
                .Include(p => p.PlanCycles)
                .ToList();
        }

        public Plan GetPlanById(Guid planId)
        {
            return _context.Plans
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == planId))
                ?? throw new InvalidOperationException("Plan by id was not found.");
        } 
    }
}
