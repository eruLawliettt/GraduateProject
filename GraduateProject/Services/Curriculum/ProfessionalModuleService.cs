using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;

namespace GraduateProject.Services.Curriculum
{
    public class ProfessionalModuleService : IProfessionalModuleService
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalModuleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProfessionalModuleAsync(ProfessionalModule professionalModule)
        {
            _context.ProfessionalModules.Add(professionalModule);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateProfessionalModuleAsync(ProfessionalModule professionalModule)
        {
            _context.ProfessionalModules.Update(professionalModule);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Логическое удаление
        /// </summary>
        public async Task<int> DeleteProfessionalModuleAsync(Guid professionalModuleId)
        {
            var professionalModule = _context.ProfessionalModules
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == professionalModuleId));

            if (professionalModule == null)
                return default;

            professionalModule.IsDeleted = true;

            return await UpdateProfessionalModuleAsync(professionalModule);
        }

        public List<ProfessionalModule> GetAllProfessionalModules()
        {
            return _context.ProfessionalModules
                .Where(p => p.IsDeleted != true)
                .ToList();
        }

        public ProfessionalModule GetProfessionalModuleById(Guid professionalModuleId)
        {
            return _context.ProfessionalModules
                .FirstOrDefault(p => (p.IsDeleted != true) && (p.Id == professionalModuleId))
                ?? throw new InvalidOperationException("ProfessionalModule by id was not found.");
        }
    }
}
