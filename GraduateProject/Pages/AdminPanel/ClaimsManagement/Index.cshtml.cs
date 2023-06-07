using GraduateProject.Data;
using GraduateProject.Entities.Identity;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GraduateProject.Pages.AdminPanel.ClaimsManagement
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private Person _person;

        public List<Person> People { get; set; }
        public List<User> Users { get; set; }
        

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;

            Users = _context.Users
                .Include(u => u.Person)
                .Where(u => u.Person == null).ToList();

            People = _context.Persons
                .Where(p => p.UserId == null).ToList();

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            bool claimExists = _context.UserClaims
                .Where(u => (u.UserId == Guid.Parse(Input.UserId)) 
                && (u.ClaimValue == Input.ClaimValue)).Any();

            if (claimExists != true)
            {
                if (Input.ClaimValue == "1")
                {
                    _context.UserClaims.Add(new IdentityUserClaim<Guid>
                    {
                        UserId = Guid.Parse(Input.UserId),
                        ClaimType = "AccessLevel",
                        ClaimValue = "1"
                    });
                }
                else if (Input.ClaimValue == "2")
                {
                    _context.UserClaims.Add(new IdentityUserClaim<Guid>
                    {
                        UserId = Guid.Parse(Input.UserId),
                        ClaimType = "AccessLevel",
                        ClaimValue = "2"
                    });
                }
                else
                {
                    _context.UserClaims.Add(new IdentityUserClaim<Guid>
                    {
                        UserId = Guid.Parse(Input.UserId),
                        ClaimType = "AccessLevel",
                        ClaimValue = "1"
                    });
                    _context.UserClaims.Add(new IdentityUserClaim<Guid>
                    {
                        UserId = Guid.Parse(Input.UserId),
                        ClaimType = "AccessLevel",
                        ClaimValue = "2"
                    });
                    _context.UserClaims.Add(new IdentityUserClaim<Guid>
                    {
                        UserId = Guid.Parse(Input.UserId),
                        ClaimType = "AccessLevel",
                        ClaimValue = "3"
                    });
                }

                _person = _context.Persons.FirstOrDefault(p => p.Id == Guid.Parse(Input.PersonId));

                _person.UserId = Guid.Parse(Input.UserId);

                _context.Persons.Update(_person);
                await _context.SaveChangesAsync();
           }

            return RedirectToPage("../Index");
        }

        public void OnGet()
        {
        }

        public class InputModel
        {
            [System.ComponentModel.DataAnnotations.Required]
            [Display(Name = "Пользователь")]
            public string UserId { get; set; }

            [System.ComponentModel.DataAnnotations.Required]
            [Display(Name = "Человек")]
            public string PersonId { get; set; }

            [System.ComponentModel.DataAnnotations.Required]
            [Display(Name = "Уровень доступа")]
            public string ClaimValue { get; set; }

        }
    }
}
