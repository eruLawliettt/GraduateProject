using GraduateProject.Entities.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Report
{
    public class ProgressReportEntityTypeConfiguration : IEntityTypeConfiguration<ProgressReport>
    {
        public void Configure(EntityTypeBuilder<ProgressReport> builder)
        {
            builder.HasOne(r => r.Semester)
                .WithMany(s => s.Reports)
                .HasForeignKey(r => r.SemesterId)
                .HasConstraintName("FK_ProgressRepots_SemesterId_Semesters_Id");
        }
    }
}
