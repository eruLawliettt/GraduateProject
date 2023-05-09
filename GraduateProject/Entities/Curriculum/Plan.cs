namespace GraduateProject.Entities.Curriculum;

public class Plan
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public Guid? GroupId { get; set; }
    
    public Group Group { get; set; }  
    public ICollection<PlanCycle> PlanCycles { get; set; }
    public ICollection<Semester> Semesters { get; set; }
}
