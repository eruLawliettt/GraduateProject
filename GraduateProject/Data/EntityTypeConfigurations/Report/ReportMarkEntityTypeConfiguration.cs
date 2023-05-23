using GraduateProject.Entities.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Report
{
    public class ReportMarkEntityTypeConfiguration : IEntityTypeConfiguration<ReportMark>
    {
        public void Configure(EntityTypeBuilder<ReportMark> builder)
        {
            builder.ToTable("ReportMarks", "report")
                .HasKey(r => new { r.ReportId, r.DisciplineId, r.StudentId})
                .HasName("PK_ReportMarks_ReportId_DisciplineId_StudentId");

            builder.HasOne(r => r.Report)
                .WithMany(re => re.ReportMarks)
                .HasForeignKey(r => r.ReportId)
                .HasConstraintName("FK_ReportMarks_ReportId_Reports_Id")
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Discipline)
                .WithMany(d => d.ReportMarks)
                .HasForeignKey(r => r.DisciplineId)
                .HasConstraintName("FK_ReportMarks_DisciplineId_Disciplines_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.Student)
                .WithMany(s => s.ReportMarks)
                .HasForeignKey(r => r.StudentId)
                .HasConstraintName("FK_ReportMarks_StudentId_Students_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
