using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface ISemesterService
    {
        Task<int> CreateSemesterAsync(Semester semester);
        Task<int> UpdateSemesterAsync(Semester semester);
        Task<int> DeleteSemesterAsync(Guid semesterId);

        List<Semester> GetAllSemesters();
        Semester GetSemesterById(Guid semesterId);
    }
}
