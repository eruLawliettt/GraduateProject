using GraduateProject.Data;
using GraduateProject.Entities.Curriculum;
using GraduateProject.Entities.Subject;
using GraduateProject.Services.Subject.Interfaces;

namespace GraduateProject.Services.Subject
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext _context;

        public PositionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePositionAsync(Position position)
        {
            _context.Positions.Add(position);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdatePositionAsync(Position position)
        {
            _context.Positions.Update(position);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePositionAsync(Guid positionId)
        {
            var position = _context.Positions
                .FirstOrDefault(c => c.Id == positionId);

            if (position == null)
                return default;

            _context.Positions.Remove(position);
            return await _context.SaveChangesAsync();
        }

        public List<Position> GetAllPositions()
        {
            return _context.Positions
                .ToList();
        }

        public Position GetPositionById(Guid positionId)
        {
            return _context.Positions
                .FirstOrDefault(c =>c.Id == positionId)
                ?? throw new InvalidOperationException("Position by id was not found.");
        }
    }
}
