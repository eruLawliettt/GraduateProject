namespace GraduateProject.Entities.Curriculum
{
    public class ProfessionalModule
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsHidden { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Количество часов на промежуточную аттестацию
        /// </summary>
        public int CertificationHours { get; set; }
        
        public Guid CertificationFormId { get; set; }

        public CertificationForm CertificationForm { get; set; }
        public ICollection<PlanCycleDiscipline> PlanCycleDisciplines { get; set; }
    }
}
