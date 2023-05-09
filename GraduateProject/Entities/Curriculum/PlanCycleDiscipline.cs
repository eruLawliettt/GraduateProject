namespace GraduateProject.Entities.Curriculum;

public class PlanCycleDiscipline
{
    // Разбить дисциплину на семестры
    public Guid Id { get; set; }

    public Guid PlanCycleId { get; set; }
    public Guid DisciplineId { get; set; }
    
    /// <summary>
    /// Количество часов на промежуточную аттестацию
    /// </summary>
    public int CertificationHours { get; set; }
     
    public Guid ProfessionalModuleId { get; set; }

    public PlanCycle PlanCycle { get; set; }
    public Discipline Discipline { get; set; }
    public ProfessionalModule ProfessionalModule { get; set; }
    public ICollection<PlanCycleDisciplineSemester> PlanCycleDisciplineSemesters { get; set; }
}
