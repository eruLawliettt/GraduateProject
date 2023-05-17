namespace GraduateProject.Entities.Subjects
{
    public class Employee : Person
    {
        public ICollection<EmployeePosition> EmployeePositions { get; set; }

        /// <summary>
        /// Группы в которых работник является руководителем
        /// </summary>
        public ICollection<Group> SupervisedGroups { get; set; }
    }
}
