#nullable enable

using GraduateProject.Entities.Identity;

namespace GraduateProject.Entities.Subject
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string? Discriminator { get; set; }
        
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 1 - Male, 0 - Female
        /// </summary>
        public bool Gender { get; set; }

        public Guid? UserId { get; set; }

        public User? User { get; set; }
    }
}
