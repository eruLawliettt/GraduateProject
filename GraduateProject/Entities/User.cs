using Microsoft.AspNetCore.Identity;

namespace GraduateProject.Entities;

public class User : IdentityUser<Guid>
{
    public Guid PersonId { get; set; }

    public Person Person { get; set; }
}
