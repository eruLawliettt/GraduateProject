namespace GraduateProject.Entities;

public class Student : Person
{   
    public Guid GroupId { get; set; }

    public Group Group { get; set; }
}
