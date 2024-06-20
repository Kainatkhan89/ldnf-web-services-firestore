using learndotnetfast_web_services.DTOs;

namespace learndotnetfast_web_services.Services.Progress
{
    public interface IProgressService
    {
        Task<ProgressDTO> GetProgressByUserIdAsync(string userId);
        Task<TutorialCompletionDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO);
        Task RemoveCompletedTutorialAsync(TutorialCompletionDTO completionDTO);
        Task RemoveAllProgressForUserAsync(string userId);
    }

}
