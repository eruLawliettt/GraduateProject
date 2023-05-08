using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Entities;

public class TeacherDiscipline
{
    public Guid TeacherId { get; set; }
    public Guid DisciplineId { get; set; }
    public Guid GroupId { get; set; }

    public Teacher Teacher { get; set; }
    public Discipline Discipline { get; set; }
    public Group Group { get; set; }
}
