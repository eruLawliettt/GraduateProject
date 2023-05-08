namespace GraduateProject.Entities.Curriculum
{   
    /// <summary>
    /// DEEP WEB SHIT
    /// </summary>
    public class EducationalPlanCycleDisciplineSemester
    {
        public Guid EducationalPlanCycleDisciplineId { get; set; }
        public Guid SemesterId { get; set; }

        /// <summary>
        /// Количество часов теоретического обучения
        /// </summary>
        public int TheoreticalHours { get; set; }
        
        /// <summary>
        /// Количество часов практического обучения
        /// </summary>
        public int PracticalHours { get; set; }

        public EducationalPlanCycleDiscipline EducationalPlanCycleDiscipline { get; set; }
        public Semester Semester { get; set; }
    }
}
