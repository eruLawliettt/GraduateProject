using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class StudyDirectionEntityTypeConfiguration : IEntityTypeConfiguration<StudyDirection>
    {
        public void Configure(EntityTypeBuilder<StudyDirection> builder)
        {
            builder.ToTable("StudyDirections", "curriculum")
                .HasKey(s => s.Id)
                .HasName("PK_StudyDirections_Id");
        }
    }
}
