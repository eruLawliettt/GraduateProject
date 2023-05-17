using GraduateProject.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Subject
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group", "subject")
                .HasKey(g => g.Id)
                .HasName("PK_Groups_Id");

            builder.HasOne(g => g.StudyDirection)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.StudyDirectionId)
                .HasConstraintName("FK_Groups_StudyDirectionId_StudyDirections_Id")
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(g => g.Supervisor)
                .WithMany(s => s.SupervisedGroups)
                .HasForeignKey(g => g.SupervisorId)
                .HasConstraintName("FK_Groups_SupervisorId_Employees_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
