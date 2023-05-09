using GraduateProject.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Curriculum
{
    public class ProfessionalModuleEntityTypeConfiguration : IEntityTypeConfiguration<ProfessionalModule>
    {
        public void Configure(EntityTypeBuilder<ProfessionalModule> builder)
        {
            builder.ToTable("ProfessionalModules", "curriculum")
                .HasKey(p => p.Id)
                .HasName("PK_ProfessionalModules_Id");

            builder.HasOne(p => p.CertificationForm)
                .WithMany(c => c.ProfessionalModules)
                .HasForeignKey(p => p.CertificationFormId)
                .HasConstraintName("FK_ProfessionalModules_CertificationFormId_CertificationForms_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
