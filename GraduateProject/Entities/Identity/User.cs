using GraduateProject.Entities.Subjects;
using Microsoft.AspNetCore.Identity;

namespace GraduateProject.Entities.Identity;

public class User : IdentityUser<Guid>
{
    public Person Person { get; set; }
}
