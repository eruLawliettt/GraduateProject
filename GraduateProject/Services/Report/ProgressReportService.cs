using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Services.Report.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateReportMarkAsync(ReportMark reportMark)
        {
            _context.ReportMarks.Add(reportMark);
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

        public List<ReportMark> GetAllReportMarks()
        {
            return _context.ReportMarks
                .Include(r => r.Report)
                .ThenInclude(r => r.Group)
                .ToList();
        }

        public ProgressReport GetProgressReportById(Guid Id)
        {
            return _context.ProgressReports
                .FirstOrDefault(p => p.Id == Id)
                ?? throw new InvalidOperationException("PR by id was not found.");
        }
    }
}
