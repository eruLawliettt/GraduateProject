using GraduateProject.Entities.Identity;
using GraduateProject.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateProject.Data.EntityTypeConfigurations.Subject
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", "subject")
                .HasKey(p => p.Id)
                .HasName("PK_Persons_Id");

            builder.HasOne(p => p.User)
                .WithOne(u => u.Person)
                .HasForeignKey<Person>(p => p.UserId)
                .HasConstraintName("FK_Persons_UserId_Users_Id");
            
            builder.HasDiscriminator(p => p.Discriminator)
                .HasValue<Employee>(nameof(Employee))
                .HasValue<Student>(nameof(Student));
        }
    }
}
