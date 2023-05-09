using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class CycleEntityTypeConfiguration : IEntityTypeConfiguration<Cycle>
    {
        public void Configure(EntityTypeBuilder<Cycle> builder)
        {
            builder.ToTable("Cycles", "curriculum")
                .HasKey(c => c.Id)
                .HasName("PK_Cycles_Id");
        }
    }
}
