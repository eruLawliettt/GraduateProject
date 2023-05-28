using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Subject;

namespace GraduateProject.Services.Subject.Interfaces
{
    public interface IPositionService
    {
        Task<int> CreatePositionAsync(Position position);
        Task<int> UpdatePositionAsync(Position position);
        Task<int> DeletePositionAsync(Guid positionId);

        List<Position> GetAllPositions();
        Position GetPositionById(Guid positionId);
    }
}
