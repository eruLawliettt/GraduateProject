using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Report
{
    public class ReportEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Report.Report>

    {
        public void Configure(EntityTypeBuilder<Entities.Report.Report> builder)
        {
            builder.ToTable("Reports", "report")
                .HasKey(r => r.Id)
                .HasName("PK_Reports_Id");

            builder.HasDiscriminator(r => r.Discriminator)
                .HasValue<ExamReport>(nameof(ExamReport))
                .HasValue<ProgressReport>(nameof(ProgressReport));

            builder.HasOne(r => r.Group)
                .WithMany(g => g.Reports)
                .HasForeignKey(r => r.GroupId)
                .HasConstraintName("FK_Reports_GroupId_Groups_Id");
            
        }
    }
}
