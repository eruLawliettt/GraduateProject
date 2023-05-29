using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraduateProject.Pages.AdminPanel.Student
{
    public class CreateModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public List<string> Genders { get; private set; } = new List<string>()
        { "Мужчина", "Женщина" };
        public List<Entities.Subject.Group> Groups { get; }

        public CreateModel(IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
            Groups = _groupService.GetAllGroups();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var gender = false;
            if (Input.Gender == "Мужчина")
                gender = true;

            var student = new Entities.Subject.Student()
            {
                FirstName = Input.FirstName,
                MiddleName = Input.MiddleName,
                LastName = Input.LastName,
                DateOfBirth = Input.DateOfBirth,
                Gender = gender,
                GroupId = Guid.Parse(Input.GroupId)
            };

            await _studentService.CreateStudentAsync(student);
           
            return RedirectToPage("Index");
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Имя")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Отчество")]
            public string MiddleName { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Дата рождения")]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [Display(Name = "Пол")]
            public string Gender { get; set; }

            [Required]
            [Display(Name = "Группа")]
            public string GroupId { get; set; }
        }
    }
}
