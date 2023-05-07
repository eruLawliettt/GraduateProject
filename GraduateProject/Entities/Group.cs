namespace GraduateProject.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime EntryDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public Guid CuratorId { get; set; }
        public Teacher Curator { get; set; }
    }
}
