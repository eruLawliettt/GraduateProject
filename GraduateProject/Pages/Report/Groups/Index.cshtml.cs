using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Report.Groups
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;

        [BindProperty(SupportsGet = true)]
        public string GroupId { get; set; }

        public Group Group { get; set; }

        public IndexModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task OnGet()
        {
            Group = _groupService.GetGroupById(Guid.Parse(GroupId));

        }
    }
}
