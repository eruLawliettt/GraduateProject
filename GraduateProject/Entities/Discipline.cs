namespace GraduateProject.Entities
{
    public class Discipline
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
