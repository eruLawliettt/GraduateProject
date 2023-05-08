namespace GraduateProject.Entities;

public class Teacher : Person
{
    public ICollection<TeacherDiscipline> TeacherDisciplines { get; set; }
}
