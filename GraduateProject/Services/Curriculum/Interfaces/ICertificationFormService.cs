using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface ICertificationFormService
    {
        Task<int> CreateCertificationFormAsync(CertificationForm certificationForm);
        Task<int> UpdateCertificationFormAsync(CertificationForm certificationForm);
        Task<int> DeleteCertificationFormAsync(Guid certificationFormId);

        List<CertificationForm> GetAllCertificationForms();
        CertificationForm GetCertificationFormById(Guid certificationFormId);
    }
}
