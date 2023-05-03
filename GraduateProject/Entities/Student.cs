namespace GraduateProject.Entities
{
    public class Student : User
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
