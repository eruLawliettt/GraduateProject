using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Report.Interfaces;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduateProject.Pages.Report
{
    [Authorize(Policy = "Teacher")]
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;
        public List<Group> Groups { get; set; }

        public void OnGet()
        {
        }

        public IndexModel(IGroupService groupService)
        {
            _groupService = groupService;
            Groups = _groupService.GetAllGroups();
        }
    }
}
