using GraduateProject.Data;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.AdminPanel.Group
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IGroupService _groupService;
        public List<Entities.Subject.Group> Groups { get; set; }

        public IndexModel(ApplicationDbContext context, IGroupService groupService)
        {
            _context = context;
            _groupService = groupService;
            Groups = _groupService.GetAllGroups();
        }
    }
}
