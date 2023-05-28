﻿using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;

namespace GraduateProject.Services.Report.Interfaces
{
    public interface IProgressReportService
    {
        Task<int> CreateProgressReportAsync(ProgressReport progressReport);
        Task<int> UpdateProgressReportAsync(ProgressReport progressReport);

        List<ProgressReport> GetAllProgressReports();
    }
}
