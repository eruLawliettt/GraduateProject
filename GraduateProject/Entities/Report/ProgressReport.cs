using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Entities.Report
{
    public class ProgressReport : Report
    {
        public Guid SemesterId { get; set; }

        public Semester Semester { get; set; }
        public ICollection<ReportMark> ReportMarks { get; set; }

    }
}
