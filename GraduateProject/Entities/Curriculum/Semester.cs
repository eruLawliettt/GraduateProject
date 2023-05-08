namespace GraduateProject.Entities.Curriculum;

public class Semester
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }
    
    public int Number { get; set; }
    
    public Guid EducationalPlanId { get; set; }
    
    public EducationalPlan EducationalPlan { get; set; }
}
