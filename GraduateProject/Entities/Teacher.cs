namespace GraduateProject.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }

        // FullName?

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
