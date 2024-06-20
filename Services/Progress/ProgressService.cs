using AutoMapper;
using learndotnetfast_web_services.Data;
using learndotnetfast_web_services.DTOs;
using learndotnetfast_web_services.Entities;
using learndotnetfast_web_services.Repositories.Progress;
using Microsoft.EntityFrameworkCore;

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
        /*public async Task<ProgressDTO> GetProgressByUserIdAsync(string userId)
        {
            var progress = await _progressRepository.GetProgressByUserIdAsync(userId);
            if (progress == null) return null;

            return _mapper.Map<ProgressDTO>(progress);
        }*/

        public async Task<ProgressDTO> GetProgressByUserIdAsync(string userId)
        {
            var progresses = await _progressRepository.GetProgressesByUserIdAsync(userId);
            if (progresses == null || !progresses.Any())
                return null;

            // Create a DTO that includes all completed tutorial IDs for the user
            var progressDTO = new ProgressDTO
            {
                UserId = userId,
                CompletedTutorialIds = progresses.Select(p => p.TutorialId).ToList()
            };

            return progressDTO;
        }

        /*   public async Task<ProgressDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO)
           {
               var progresses = await _progressRepository.GetProgressesByUserIdAsync(completionDTO.UserId);
               if (progresses == null || !progresses.Any())
               {
                   progress = new Entities.Progress
                   {
                       UserId = completionDTO.UserId,
                       TutorialId = completionDTO.TutorialId
                   };
                   _context.Progresses.Add(progress);
               }
               else
               {
                   var tutorial = await _context.Tutorials.FindAsync(completionDTO.TutorialId);
                   if (tutorial != null && progress.TutorialId != tutorial.Id)
                   {
                       progress.TutorialId = tutorial.Id;  
                   }
               }

               await _context.SaveChangesAsync();
               return _mapper.Map<ProgressDTO>(progress);
           }*/

        public async Task<ProgressDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO)
        {
            // Check if the tutorial exists to prevent adding invalid tutorial IDs
            var tutorialExists = await _context.Tutorials.AnyAsync(t => t.Id == completionDTO.TutorialId);
            if (!tutorialExists)
            {
                throw new KeyNotFoundException($"No tutorial found with ID {completionDTO.TutorialId}.");
            }

            // Create a new progress record for each tutorial completion
            var newProgress = new Entities.Progress
            {
                UserId = completionDTO.UserId,
                TutorialId = completionDTO.TutorialId
            };

            _context.Progresses.Add(newProgress);
            await _context.SaveChangesAsync();

            // Return the newly created progress mapped to a DTO
            return _mapper.Map<ProgressDTO>(newProgress);
        }

    }

}
