using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Identity;
using GraduateProject.Entities.Report;
using GraduateProject.Entities.Subject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GraduateProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        #region Curriculum

        public DbSet<CertificationForm> CertificationForms { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanCycle> PlanCycles { get; set; }
        public DbSet<PlanCycleDiscipline> PlanCycleDisciplines { get; set; }
        public DbSet<PlanCycleDisciplineSemester> PlanCycleDisciplineSemesters { get; set; }
        public DbSet<ProfessionalModule> ProfessionalModules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<StudyDirection> StudyDirections { get; set; }

        #endregion

        #region Subject

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Student> Students { get; set; }

        #endregion

        #region Report

        public DbSet<ExamReport> ExamReports { get; set; }
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportMark> ReportMarks { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "identity");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "identity");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "identity");
            builder.Entity<User>().ToTable("Users", "identity");
            builder.Entity<Role>().ToTable("Roles", "identity");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "identity");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "identity");
        }
    }
}