using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class CertificationFormEntityTypeConfiguration : IEntityTypeConfiguration<CertificationForm>
    {
        public void Configure(EntityTypeBuilder<CertificationForm> builder)
        {
            builder.ToTable("CertificationForms", "curriculum")
                .HasKey(t => t.Id)
                .HasName("PK_CertificationForms_Id");
        }
    }
}
