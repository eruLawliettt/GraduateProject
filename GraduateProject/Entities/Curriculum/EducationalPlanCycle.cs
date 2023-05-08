namespace GraduateProject.Entities.Curriculum;

public class EducationalPlanCycle
{
    public Guid Id { get; set; }

    public Guid EducationalPlanId { get; set; }
    public Guid EducationalCycleId { get; set; }

    public EducationalPlan EducationalPlan { get; set; }
    public EducationalCycle EducationalCycle { get; set; }
    
    // Коллекция объектов, которыми представлена дисциплина учебного плана
}
