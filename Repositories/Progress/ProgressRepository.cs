namespace learndotnetfast_web_services.Repositories.Progress
{
    using learndotnetfast_web_services.Entities;
    using learndotnetfast_web_services.Data;
    using Microsoft.EntityFrameworkCore;
    public class ProgressRepository : IProgressRepository
    {
        private readonly DataContext _context;

        public ProgressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Progress> GetProgressByUserIdAsync(string userId)
        {
            return await _context.Progresses
                                 .Include(p => p.CompletedTutorials)
                                 .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task AddProgressAsync(Progress progress)
        {
            _context.Progresses.Add(progress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgressAsync(Progress progress)
        {
            _context.Progresses.Update(progress);
            await _context.SaveChangesAsync();
        }
    }
}
