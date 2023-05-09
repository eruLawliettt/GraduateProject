namespace GraduateProject.Entities.Curriculum
{   
    /// <summary>
    /// DEEP WEB SHIT
    /// </summary>
    public class PlanCycleDisciplineSemester
    {
        public Guid Id { get; set; }
        public Guid PlanCycleDisciplineId { get; set; }
        public Guid SemesterId { get; set; }
         
        /// <summary>
        /// Количество часов теоретического обучения
        /// </summary>
        public int TheoreticalHours { get; set; }
        
        /// <summary>
        /// Количество часов практического обучения
        /// </summary>
        public int PracticalHours { get; set; }

        public Guid CertificationFormId { get; set; }

        public PlanCycleDiscipline PlanCycleDiscipline { get; set; }
        public Semester Semester { get; set; }
        public CertificationForm CertificationForm { get; set; }
    }
}
