using GraduateProject.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Subject
{
    public class EmployeePositionEntityTypeConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.ToTable("EmployeePositions", "subject")
                .HasKey(e => new {e.EmployeeId, e.PositionId})
                .HasName("PK_EmployeePositions_EmployeeId_PositionId");

            builder.HasOne(e => e.Employee)
                .WithMany(ep => ep.EmployeePositions)
                .HasForeignKey(e => e.EmployeeId)
                .HasConstraintName("FK_EmployeePositions_EmployeeId_Employees_Id");

            builder.HasOne(e => e.Position)
                .WithMany(p => p.EmployeePositions)
                .HasForeignKey(e => e.PositionId)
                .HasConstraintName("FK_EmployeePositions_PositionId_Positions_Id");
        }
    }
}
