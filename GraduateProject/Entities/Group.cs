using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Entities;

public class Group
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public string Name { get; set; }
    public DateTime EntryDate { get; set; }

    public Guid StudyDirectionId { get; set; }
    
    public StudyDirection StudyDirection { get; set; }
    public Plan Plan { get; set; }
}
