namespace GraduateProject.Entities.Curriculum;

public class PlanCycle
{
    public Guid Id { get; set; }

    public Guid PlanId { get; set; }
    public Guid CycleId { get; set; }

    public Plan Plan { get; set; }
    public Cycle Cycle { get; set; }
     
    public ICollection<PlanCycleDiscipline> PlanCycleDisciplines { get; set; }
}
