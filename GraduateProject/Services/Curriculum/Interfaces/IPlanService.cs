using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IPlanService
    {
        Task<int> CreatePlanAsync(Plan plan);
        Task<int> UpdatePlanAsync(Plan plan);
        Task<int> DeletePlanAsync(Guid planId);

        List<Plan> GetAllPlans();
        Plan GetPlanById(Guid planId);
    }
}
