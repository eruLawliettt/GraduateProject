using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Subject;

namespace GraduateProject.Entities.Report
{
    public class ReportMark
    {
        public Guid ReportId { get; set; }
        public Guid DisciplineId { get; set; }
        public Guid StudentId { get; set; }

        public string Mark { get; set; }

        public ProgressReport Report { get; set; }
        public Discipline Discipline { get; set; }
        public Student Student { get; set; }
    }
}
