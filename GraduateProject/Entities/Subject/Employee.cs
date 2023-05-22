using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Entities.Subject
{
    public class Employee : Person
    {
        public ICollection<EmployeePosition> EmployeePositions { get; set; }

        /// <summary>
        /// Группы в которых работник является руководителем
        /// </summary>
        public ICollection<Group> SupervisedGroups { get; set; }
        public ICollection<PlanCycleDisciplineSemester> PlanCycleDisciplineSemesters { get; set; }
    }
}
