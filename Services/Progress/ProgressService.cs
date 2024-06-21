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

        /* public async Task<TutorialCompletionDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO)
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
             return _mapper.Map<TutorialCompletionDTO>(newProgress);
         }
 */
        public async Task<TutorialCompletionDTO> AddCompletedTutorialAsync(TutorialCompletionDTO completionDTO)
        {
            try
            {
                // Ensure the tutorial exists
                var tutorialExists = await _context.Tutorials.AnyAsync(t => t.Id == completionDTO.TutorialId);
                if (!tutorialExists)
                {
                    throw new KeyNotFoundException($"No tutorial found with ID {completionDTO.TutorialId}.");
                }

                // Create a new progress record
                var newProgress = new Entities.Progress
                {
                    UserId = completionDTO.UserId,
                    TutorialId = completionDTO.TutorialId
                };

                _context.Progresses.Add(newProgress);
                await _context.SaveChangesAsync();

                // Return the DTO directly, since it already represents the completed tutorial
                return new TutorialCompletionDTO
                {
                    Id = newProgress.Id,  // Optionally return the database-generated ID
                    UserId = completionDTO.UserId,
                    TutorialId = completionDTO.TutorialId
                };
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow a user-friendly message
                // You should use a proper logging mechanism
                throw new ApplicationException($"An error occurred when adding tutorial completion: {ex.Message}", ex);
            }
        }

        public async Task RemoveCompletedTutorialAsync(TutorialCompletionDTO completionDTO)
        {
            // Find the progress record to delete
            var progress = await _context.Progresses
                                         .FirstOrDefaultAsync(p => p.UserId == completionDTO.UserId && p.TutorialId == completionDTO.TutorialId);

            if (progress == null)
            {
                throw new KeyNotFoundException($"No completion record found for user {completionDTO.UserId} with tutorial ID {completionDTO.TutorialId}.");
            }

            // Remove the progress record
            _context.Progresses.Remove(progress);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAllProgressForUserAsync(string userId)
        {
            // Retrieve all progress records for the given user
            var progresses = await _context.Progresses
                                           .Where(p => p.UserId == userId)
                                           .ToListAsync();

            if (progresses.Count == 0)
            {
                throw new KeyNotFoundException($"No progress records found for user {userId}.");
            }

            // Remove all fetched progress records
            _context.Progresses.RemoveRange(progresses);
            await _context.SaveChangesAsync();
        }



    }

}
