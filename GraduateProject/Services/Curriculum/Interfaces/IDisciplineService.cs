using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IDisciplineService
    {
        Task<int> CreateDisciplineAsync(Discipline discipline);
        Task<int> UpdateDisciplineAsync(Discipline discipline);
        Task<int> DeleteDisciplineAsync(Guid disciplineId);

        List<Discipline> GetAllDisciplines();
        Discipline GetDisciplineById(Guid disciplineId);
    }
}
