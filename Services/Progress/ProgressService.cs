using AutoMapper;
using learndotnetfast_web_services.Data;
using learndotnetfast_web_services.DTOs;
using learndotnetfast_web_services.Entities;
using learndotnetfast_web_services.Repositories.Progress;

namespace learndotnetfast_web_services.Services.Progress
{
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProgressService(IProgressRepository progressRepository, IMapper mapper, DataContext context)
        {
            _progressRepository = progressRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProgressDTO> GetProgressByUserIdAsync(string userId)
        {
            var progress = await _progressRepository.GetProgressByUserIdAsync(userId);
            if (progress == null) return null;

            return _mapper.Map<ProgressDTO>(progress);
        }

        public async Task<ProgressDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO)
        {
            var progress = await _progressRepository.GetProgressByUserIdAsync(completionDTO.UserId);
            if (progress == null)
            {
                progress = new Entities.Progress
                {
                    UserId = completionDTO.UserId,
                    CompletedTutorials = new List<Tutorial> { new Tutorial { Id = completionDTO.TutorialId } }
                };
                _context.Progresses.Add(progress);
            }
            else
            {
                var tutorial = await _context.Tutorials.FindAsync(completionDTO.TutorialId);
                if (tutorial != null && !progress.CompletedTutorials.Contains(tutorial))
                {
                    progress.CompletedTutorials.Add(tutorial);
                }
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<ProgressDTO>(progress);
        }
    }

}
