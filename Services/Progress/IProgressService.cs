using learndotnetfast_web_services.DTOs;

namespace learndotnetfast_web_services.Services.Progress
{
    public interface IProgressService
    {
        Task<ProgressDTO> GetProgressByUserIdAsync(string userId);
        Task<ProgressDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO);
    }

}
