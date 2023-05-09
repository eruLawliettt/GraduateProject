namespace GraduateProject.Entities.Curriculum;

public class Discipline
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<PlanCycleDiscipline> PlanCycleDisciplines { get; set; } 
}
