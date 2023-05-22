namespace GraduateProject.Entities.Subject
{
    public class EmployeePosition
    {
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }

        public Employee Employee { get; set; }
        public Position Position { get; set; }
    }
}