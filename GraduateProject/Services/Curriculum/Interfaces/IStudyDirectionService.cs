using GraduateProject.Entities.Curriculum;

namespace GraduateProject.Services.Curriculum.Interfaces
{
    public interface IStudyDirectionService
    {
        Task<int> CreateStudyDirectionAsync(StudyDirection studyDirection);
        Task<int> UpdateStudyDirectionAsync(StudyDirection studyDirection);
        Task<int> DeleteStudyDirectionAsync(Guid studyDirectionId);

        List<StudyDirection> GetAllStudyDirections();
        StudyDirection GetStudyDirectionById(Guid studyDirectionId);
    }
}
