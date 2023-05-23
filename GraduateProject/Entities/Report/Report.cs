#nullable enable
using GraduateProject.Entities.Subject;

namespace GraduateProject.Entities.Report
{
    public class Report
    {
        public Guid Id { get; set; }
        public string? Discriminator { get; set; }

        public string Number { get; set; }
        public DateTime Date { get; set; }
        
        public Guid GroupId { get; set; }

        public Group Group { get; set; }
        public ICollection<ReportMark> ReportMarks { get; set; }
    }
}
