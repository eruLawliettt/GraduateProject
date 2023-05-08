using Microsoft.AspNetCore.Identity;

namespace GraduateProject.Entities;

public class Role : IdentityRole<Guid>
{
    public string Description { get; set; }
}
