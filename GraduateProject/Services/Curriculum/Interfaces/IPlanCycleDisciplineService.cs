using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IPlanCycleDisciplineService
    {
        Task<int> CreatePlanCycleDisciplineAsync(PlanCycleDiscipline planCycleDiscipline);
        Task<int> UpdatePlanCycleDisciplineAsync(PlanCycleDiscipline planCycleDiscipline);
        Task<int> DeletePlanCycleDisciplineAsync(Guid planCycleDisciplineId);

        List<PlanCycleDiscipline> GetAllPlanCycleDisciplines();
        PlanCycleDiscipline GetPlanCycleDisciplineById(Guid planCycleDisciplineId);
    }
}
