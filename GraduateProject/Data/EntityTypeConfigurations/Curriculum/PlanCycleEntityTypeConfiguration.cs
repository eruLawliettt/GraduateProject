using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class PlanCycleEntityTypeConfiguration : IEntityTypeConfiguration<PlanCycle>
    {
        public void Configure(EntityTypeBuilder<PlanCycle> builder)
        {
            builder.ToTable("PlanCycles", "curriculum")
                .HasKey(pc => pc.Id)
                .HasName("PK_PlanCycles_Id");

            builder.HasIndex(pc => new { pc.PlanId, pc.CycleId })
                .IsUnique();

            builder.HasOne(pc => pc.Plan)
                .WithMany(p => p.PlanCycles)
                .HasForeignKey(pc => pc.PlanId)
                .HasConstraintName("FK_PlanCycles_PlanId_Plans_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pc => pc.Cycle)
                .WithMany(c => c.PlanCycles)
                .HasForeignKey(pc => pc.CycleId)
                .HasConstraintName("FK_PlanCycles_CycleId_Cycles_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
