using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Entities.Subject;

public class Group
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public string Name { get; set; }
    public DateTime EntryDate { get; set; }

    public Guid StudyDirectionId { get; set; }

    /// <summary>
    /// Идентификатор руководителя группы
    /// </summary>
    public Guid SupervisorId { get; set; }

    public StudyDirection StudyDirection { get; set; }

    /// <summary>
    /// Куратор
    /// </summary>
    public Employee Supervisor { get; set; }
    public Plan Plan { get; set; }
    public ICollection<Student> Students { get; set; }
}
