using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Mark
{
    [Authorize(Policy = "Teacher")]
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;
        public List<Group> Groups { get; set; }

        public IndexModel(IGroupService groupService)
        {
            _groupService = groupService;
            Groups = _groupService.GetAllGroups();
        }

        public void OnGet()
        {
        }

    }
}
