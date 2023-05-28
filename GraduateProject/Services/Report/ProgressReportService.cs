using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Services.Report.Interfaces;

namespace GraduateProject.Services.Report
{
    public class ProgressReportService : IProgressReportService
    {
        private readonly ApplicationDbContext _context;

        public ProgressReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProgressReportAsync(ProgressReport progressReport)
        {
            _context.ProgressReports.Add(progressReport);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateProgressReportAsync(ProgressReport progressReport)
        {
            _context.ProgressReports.Update(progressReport);
            return await _context.SaveChangesAsync();
        }

        public List<ProgressReport> GetAllProgressReports()
        {            
            return _context.ProgressReports
                .ToList();          
        }  
    }
}
