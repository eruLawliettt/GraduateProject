namespace GraduateProject.Entities.Curriculum;

public class StudyDirection
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Длительность обучения в месяцах.
    /// </summary>
    public int Period { get; set; }
     
    public ICollection<Group> Groups { get; set; }
}
