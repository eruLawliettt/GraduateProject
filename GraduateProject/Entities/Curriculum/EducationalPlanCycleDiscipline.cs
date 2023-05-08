namespace GraduateProject.Entities.Curriculum;

public class EducationalPlanCycleDiscipline
{
    // Разбить дисциплину на семестры
    public Guid Id { get; set; }

    public Guid EducationalPlanCycleId { get; set; }
    public Guid DisciplineId { get; set; }

    /// <summary>
    /// Общее количество часов
    /// </summary>
    public int TotalHours => TheoreticalHours + PracticalHours;

    /// <summary>
    /// Количество часов теоретического обучения
    /// </summary>
    public int TheoreticalHours => 0;

    /// <summary>
    /// Количество часов практического обучения
    /// </summary>
    public int PracticalHours => 0;
    
    /// <summary>
    /// Количество часов на промежуточную аттестацию
    /// </summary>
    public int CertificationHours { get; set; }

    public EducationalPlanCycle EducationalPlanCycle { get; set; }
    public Discipline Discipline { get; set; }
    public ICollection<EducationalPlanCycleDisciplineSemester> EducationalPlanCycleDisciplineSemesters { get; set; }
}
