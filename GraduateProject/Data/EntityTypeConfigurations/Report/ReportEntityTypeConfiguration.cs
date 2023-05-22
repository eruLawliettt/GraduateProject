using GraduateProject.Entities.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Report
{
    public class ReportEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Report.Report>

    {
        public void Configure(EntityTypeBuilder<Entities.Report.Report> builder)
        {
            throw new NotImplementedException();
        }
    }
}
