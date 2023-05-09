using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class PlanCycleDisciplineEntityTypeConfiguration : IEntityTypeConfiguration<PlanCycleDiscipline>
    {
        public void Configure(EntityTypeBuilder<PlanCycleDiscipline> builder)
        {
            builder.ToTable("PlanCycleDisciplines", "curriculum")
                .HasKey(p => p.Id)
                .HasName("PK_PlanCycleDisciplines_Id");

            builder.HasIndex(p => new { p.PlanCycleId, p.DisciplineId })
                .IsUnique();

            builder.HasOne(p => p.PlanCycle)
                .WithMany(pc => pc.PlanCycleDisciplines)
                .HasForeignKey(p => p.PlanCycleId)
                .HasConstraintName("FK_PlanCycleDiscipline_PlanCycleId_PlanCycles_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Discipline)
                .WithMany(d => d.PlanCycleDisciplines)
                .HasForeignKey(p => p.DisciplineId)
                .HasConstraintName("FK_PlanCycleDiscipline_DisciplineId_Disciplines_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProfessionalModule)
                .WithMany(pm => pm.PlanCycleDisciplines)
                .HasForeignKey(p => p.ProfessionalModuleId)
                .HasConstraintName("FK_PlanCycleDiscipline_ProfessionalModuleId_ProfessionalModules_Id")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
