using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IPlanCycleDisciplineSemesterService
    {
        Task<int> CreatePlanCycleDisciplineSemesterAsync(PlanCycleDisciplineSemester planCycleDisciplineSemester);
        Task<int> UpdatePlanCycleDisciplineSemesterAsync(PlanCycleDisciplineSemester planCycleDisciplineSemester);
        Task<int> DeletePlanCycleDisciplineSemesterAsync(Guid planCycleDisciplineSemesterId);

        List<PlanCycleDisciplineSemester> GetAllPlanCycleDisciplineSemesters();
        PlanCycleDisciplineSemester GetPlanCycleDisciplineSemesterById(Guid planCycleDisciplineSemesterId);
    }
}
