using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class PlanCycleDisciplineSemesterService : IPlanCycleDisciplineSemesterService
    {
        private readonly ApplicationDbContext _context;

        public PlanCycleDisciplineSemesterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlanCycleDisciplineSemesterAsync(PlanCycleDisciplineSemester planCycleDisciplineSemester)
        {
            _context.PlanCycleDisciplineSemesters.Add(planCycleDisciplineSemester);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePlanCycleDisciplineSemesterAsync(PlanCycleDisciplineSemester planCycleDisciplineSemester)
        {
            _context.PlanCycleDisciplineSemesters.Update(planCycleDisciplineSemester);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление не логическое
        /// </summary>
        public async Task<int> DeletePlanCycleDisciplineSemesterAsync(Guid planCycleDisciplineSemesterId)
        {
            var planCycleDisciplineSemester = _context.PlanCycleDisciplineSemesters
                .FirstOrDefault(p => p.Id == planCycleDisciplineSemesterId);

            if (planCycleDisciplineSemester == null)
                return default;

            _context.PlanCycleDisciplineSemesters.Remove(planCycleDisciplineSemester);

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Нет проверки на IsDeleted
        /// </summary>
        public List<PlanCycleDisciplineSemester> GetAllPlanCycleDisciplineSemesters()
        {
            return _context.PlanCycleDisciplineSemesters
                .ToList();
        }

        /// <summary>
        /// Нет проверки на IsDeleted
        /// </summary>
        public PlanCycleDisciplineSemester GetPlanCycleDisciplineSemesterById(Guid planCycleDisciplineSemesterId)
        {
            return _context.PlanCycleDisciplineSemesters
                .FirstOrDefault(c => c.Id == planCycleDisciplineSemesterId)
                ?? throw new InvalidOperationException("PlanCycleDisciplineSemester by id was not found.");
        }
    }
}
