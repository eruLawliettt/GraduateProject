namespace GraduateProject.Entities
{
    public class Student
    {
        public Guid Id { get; set; }     
        
        // FullName?      

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
