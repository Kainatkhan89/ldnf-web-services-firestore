using System.Collections.Generic;
using System.Threading.Tasks;
using learndotnetfast_web_services.DTOs;

namespace learndotnetfast_web_services.Services.Tutorials
{  
    public interface ITutorialService
    {
        Task<List<TutorialDTO>> GetTutorialsByModuleIdAsync(int moduleId);
        Task<TutorialDTO> GetTutorialByIdAsync(int id);
        Task<TutorialDTO> SaveTutorialAsync(TutorialDTO tutorialDTO);
        Task<List<TutorialDTO>> SaveTutorialsAsync(List<TutorialDTO> tutorialDTOs);
        Task DeleteTutorialByIdAsync(int id);
    }

}
