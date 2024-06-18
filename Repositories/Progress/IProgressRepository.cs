using learndotnetfast_web_services.DTOs;

namespace learndotnetfast_web_services.Repositories.Progress
{
    using learndotnetfast_web_services.Entities;
    public interface IProgressRepository
    {
        Task<Progress> GetProgressByUserIdAsync(string userId);
        Task AddProgressAsync(Progress progress);
        Task UpdateProgressAsync(Progress progress);
    }

}
