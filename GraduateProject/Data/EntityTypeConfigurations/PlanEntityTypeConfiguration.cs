using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations;

public class PlanEntityTypeConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        throw new NotImplementedException();
    }
}
