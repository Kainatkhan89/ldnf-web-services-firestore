namespace learndotnetfast_web_services.Services.Tutorials
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using learndotnetfast_web_services.DTOs;
    using learndotnetfast_web_services.Entities;
    using learndotnetfast_web_services.Repositories.Tutorial;

    public class TutorialService : ITutorialService
    {
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IMapper _mapper;

        public TutorialService(ITutorialRepository tutorialRepository, IMapper mapper)
        {
            _tutorialRepository = tutorialRepository;
            _mapper = mapper;
        }

        public async Task<List<TutorialDTO>> GetTutorialsByModuleIdAsync(int moduleId)
        {
            var tutorials = await _tutorialRepository.GetTutorialsByModuleIdAsync(moduleId);
            return _mapper.Map<List<TutorialDTO>>(tutorials);
        }

        public async Task<TutorialDTO> GetTutorialByIdAsync(int id)
        {
            var tutorial = await _tutorialRepository.FindByIdAsync(id);
            if (tutorial == null)
                throw new KeyNotFoundException($"No tutorial found with ID {id}.");
            return _mapper.Map<TutorialDTO>(tutorial);
        }

        public async Task<TutorialDTO> SaveTutorialAsync(TutorialDTO tutorialDTO)
        {
            var tutorial = _mapper.Map<Tutorial>(tutorialDTO);
            var savedTutorial = await _tutorialRepository.SaveAsync(tutorial);
            return _mapper.Map<TutorialDTO>(savedTutorial);
        }

        public async Task<List<TutorialDTO>> SaveTutorialsAsync(List<TutorialDTO> tutorialDTOs)
        {
            var tutorials = _mapper.Map<List<Tutorial>>(tutorialDTOs);
            var savedTutorials = await _tutorialRepository.SaveRangeAsync(tutorials);
            return _mapper.Map<List<TutorialDTO>>(savedTutorials);
        }

        public async Task DeleteTutorialByIdAsync(int id)
        {
            await _tutorialRepository.DeleteByIdAsync(id);
        }
    }

}
