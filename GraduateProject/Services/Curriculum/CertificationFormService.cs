using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace GraduateProject.Services.Curriculum
{
    public class CertificationFormService : ICertificationFormService
    {
        private readonly ApplicationDbContext _context;

        public CertificationFormService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCertificationFormAsync(CertificationForm certificationForm)
        {
            _context.CertificationForms.Add(certificationForm);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCertificationFormAsync(CertificationForm certificationForm)
        {
            _context.CertificationForms.Update(certificationForm);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeleteCertificationFormAsync(Guid certificationFormId)
        {
            var certificationForm = _context.CertificationForms
                .FirstOrDefault(c => c.Id == certificationFormId);

            if (certificationForm == null)             
                return default;
            
            certificationForm.IsDeleted = true;

            return await UpdateCertificationFormAsync(certificationForm);
        }

        public List<CertificationForm> GetAllCertificationForms()
        {
            return _context.CertificationForms
                .Where(c => c.IsDeleted != true)
                .ToList();
        }

        public CertificationForm GetCertificationFormById(Guid certificationFormId)
        {
            return _context.CertificationForms
           .FirstOrDefault(c => (c.IsDeleted != true) && (c.Id == certificationFormId))
            ?? throw new InvalidOperationException("Certification Form by id was not found.");
        }

       
    }
}
