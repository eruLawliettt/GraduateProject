namespace GraduateProject.Entities.Curriculum;

public class Semester
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }
    
    public int Number { get; set; }
    
    public Guid PlanId { get; set; }
    
    public Plan Plan { get; set; }
    public ICollection<PlanCycleDisciplineSemester> PlanCycleDisciplineSemesters { get; set; }
}
