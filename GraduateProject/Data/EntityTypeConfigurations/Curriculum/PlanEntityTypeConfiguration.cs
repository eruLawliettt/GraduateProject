using GraduateProject.Entities;
using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum;

public class PlanEntityTypeConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans", "curriculum")
            .HasKey(p => p.Id)
            .HasName("PK_Plans_Id");

        builder.HasOne(p => p.Group)
            .WithOne(g => g.Plan)
            .HasForeignKey<Plan>(p => p.GroupId)
            .HasConstraintName("PK_Plans_GroupId_Groups_Id")
            .OnDelete(DeleteBehavior.NoAction);

    }
}
