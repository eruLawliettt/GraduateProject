using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface ICycleService
    {
        Task<int> CreateCycleAsync(Cycle cycle);
        Task<int> UpdateCycleAsync(Cycle cycle);
        Task<int> DeleteCycleAsync(Guid cycleId);

        List<Cycle> GetAllCycles();
        Cycle GetCycleById(Guid cycleId);
    }
}
