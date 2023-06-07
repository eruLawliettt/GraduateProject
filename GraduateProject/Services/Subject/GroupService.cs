using GraduateProject.Data;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraduateProject.Services.Subject
{

    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateGroupAsync(Group group)
        {
            _context.Groups.Add(group);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateGroupAsync(Group group)
        {
            _context.Groups.Update(group);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteGroupAsync(Guid groupId)
        {
            var group = _context.Groups
                .FirstOrDefault(c => c.Id == groupId);

            if (group == null)
                return default;

            group.IsDeleted = true;

            return await UpdateGroupAsync(group);
        }

        public List<Group> GetAllGroups()
        {
            return _context.Groups
                .Include(g => g.StudyDirection)
                .Include(g => g.Students)
                .ThenInclude(s => s.ReportMarks)
                .ThenInclude(r => r.Report)
                .Include(g => g.Supervisor)              
                .ToList();
        }

        public Group GetGroupById(Guid groupId)
        {
            return _context.Groups
                .Include(g => g.Plan)
                .ThenInclude(p => p.Semesters)
                .Include(g => g.Students)
                .ThenInclude(s => s.ReportMarks)
                .ThenInclude(r => r.Report)
                .ThenInclude(r => r.Semester)
                .FirstOrDefault(c => c.Id == groupId)                
                ?? throw new InvalidOperationException("Group by id was not found.");
        }


    }
}
