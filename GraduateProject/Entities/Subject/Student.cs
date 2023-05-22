using GraduateProject.Entities.Report;

namespace GraduateProject.Entities.Subject
{
    public class Student : Person
    {
        public Guid GroupId { get; set; }
        
        public Group Group { get; set; }
        public ICollection<ReportMark> ReportMarks { get; set; }
    }
}
