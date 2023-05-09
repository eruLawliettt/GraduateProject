using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class SemesterEntityTypeConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.ToTable("Semesters", "curriculum")
                .HasKey(s => s.Id)
                .HasName("PK_Semesters_Id");

            builder.HasOne(s => s.Plan)
                .WithMany(p => p.Semesters)
                .HasForeignKey(s => s.PlanId)
                .HasConstraintName("FK_Semesters_PlanId_Plan_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
