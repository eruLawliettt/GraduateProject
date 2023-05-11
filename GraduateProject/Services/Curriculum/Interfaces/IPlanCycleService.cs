using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IPlanCycleService
    {
        Task<int> CreatePlanCycleAsync(PlanCycle planCycle);
        Task<int> UpdatePlanCycleAsync(PlanCycle planCycle);
        Task<int> DeletePlanCycleAsync(Guid planCycleId);

        List<PlanCycle> GetAllPlanCycles();
        PlanCycle GetPlanCycleById(Guid planCycleId);
    }
}
