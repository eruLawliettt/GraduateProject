using GraduateProject.Entities.Subject;

namespace GraduateProject.Services.Subject.Interfaces
{
    public interface IGroupService
    {
        Task<int> CreateGroupAsync(Group group);
        Task<int> UpdateGroupAsync(Group group);
        Task<int> DeleteGroupAsync(Guid groupId);

        List<Group> GetAllGroups();
        Group GetGroupById(Guid groupId);
    }
}
