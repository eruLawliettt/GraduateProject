using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IProfessionalModuleService
    {
        Task<int> CreateProfessionalModuleAsync(ProfessionalModule professionalModule);
        Task<int> UpdateProfessionalModuleAsync(ProfessionalModule professionalModule);
        Task<int> DeleteProfessionalModuleAsync(Guid professionalModuleId);

        List<ProfessionalModule> GetAllProfessionalModules();
        ProfessionalModule GetProfessionalModuleById(Guid professionalModuleId);
    }
}
