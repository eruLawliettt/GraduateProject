﻿namespace GraduateProject.Entities.Curriculum
{
    public class CertificationForm
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsHidden { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ProfessionalModule> ProfessionalModules { get; set; }
        public ICollection<PlanCycleDisciplineSemester> PlanCycleDisciplineSemesters { get; set; } 
    }
}
