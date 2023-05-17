using Microsoft.AspNetCore.Identity;

namespace GraduateProject.Entities.Identity;

public class Role : IdentityRole<Guid>
{
    public string Description { get; set; }
}
