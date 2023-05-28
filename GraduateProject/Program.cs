using GraduateProject.Data;
using GraduateProject.Entities.Identity;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Curriculum;
using GraduateProject.Services.Curriculum.Interfaces;
using GraduateProject.Services.Report;
using GraduateProject.Services.Report.Interfaces;
using GraduateProject.Services.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

#region Services
builder.Services.AddTransient<ApplicationDbContext>();
builder.Services.AddTransient<IPlanService, PlanService>();
builder.Services.AddTransient<IStudyDirectionService, StudyDirectionService>();
builder.Services.AddTransient<ICycleService, CycleService>();
builder.Services.AddTransient<ICertificationFormService, CertificationFormService>();
builder.Services.AddTransient<IProfessionalModuleService, ProfessionalModuleService>();
builder.Services.AddTransient<IDisciplineService, DisciplineService>();
builder.Services.AddTransient<ISemesterService, SemesterService>();
builder.Services.AddTransient<IProgressReportService, ProgressReportService>();
builder.Services.AddTransient<IPositionService, PositionService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

#endregion

builder.Services.AddRazorPages();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
