namespace GraduateProject.Entities.Curriculum;

public class EducationalCycle
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public string Code { get; set; }
    public string Name { get; set; }
    
    public ICollection<EducationalPlanCycle> EducationalPlanCycles { get; set; }
}
