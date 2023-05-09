using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class PlanCycleDisciplineSemesterEntityTypeConfiguration : IEntityTypeConfiguration<PlanCycleDisciplineSemester>
    {
        public void Configure(EntityTypeBuilder<PlanCycleDisciplineSemester> builder)
        {
            builder.ToTable("PlanCycleDisciplineSemesters", "curriculum")
                .HasKey(p => p.Id)
                .HasName("PK_PlanCycleDisciplineSemesters_Id");

            builder.HasIndex(p => new { p.PlanCycleDisciplineId, p.SemesterId })
                .IsUnique();

            builder.HasOne(p => p.PlanCycleDiscipline)
                .WithMany(pc => pc.PlanCycleDisciplineSemesters)
                .HasForeignKey(p => p.PlanCycleDisciplineId)
                .HasConstraintName("FK_PlanCycleDisciplineSemesters_PlanCycleDisciplineId_PlanCycleDisciplines_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Semester)
                .WithMany(s => s.PlanCycleDisciplineSemesters)
                .HasForeignKey(p => p.SemesterId)
                .HasConstraintName("FK_PlanCycleDisciplineSemesters_SemesterId_Semesters_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.CertificationForm)
                .WithMany(c => c.PlanCycleDisciplineSemesters)
                .HasForeignKey(p => p.CertificationFormId)
                .HasConstraintName("FK_PlanCycleDisciplineSemesters_CertificationFormId_CertificationForms_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
