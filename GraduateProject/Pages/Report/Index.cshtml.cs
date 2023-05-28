using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Report.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProgressReportService _progressReportService;
        public List<ProgressReport> Reports { get; set; }

        public void OnGet()
        {
        }

        public IndexModel(ApplicationDbContext context, IProgressReportService progressReportService)
        {
            _context = context;   
            _progressReportService = progressReportService;
            Reports = _progressReportService.GetAllProgressReports();
        }
    }
}
