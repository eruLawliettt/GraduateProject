using GraduateProject.Entities.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Report
{
    public class ExamReportEntityTypeConfiguration : IEntityTypeConfiguration<ExamReport>
    {
        public void Configure(EntityTypeBuilder<ExamReport> builder)
        {          
        }
    }
}
