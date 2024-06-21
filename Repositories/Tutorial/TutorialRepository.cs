namespace learndotnetfast_web_services.Repositories.Tutorial
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using learndotnetfast_web_services.Data;
    using learndotnetfast_web_services.Entities;

    public class TutorialRepository : ITutorialRepository
    {
        private readonly DataContext _context;

        public TutorialRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Tutorial>> GetTutorialsByModuleIdAsync(int moduleId)
        {
            return await _context.Tutorials.Where(t => t.ModuleId == moduleId).ToListAsync();
        }

        public async Task<Tutorial> SaveAsync(Tutorial tutorial)
        {
            _context.Tutorials.Add(tutorial);
            await _context.SaveChangesAsync();
            return tutorial;
        }

        public async Task<List<Tutorial>> SaveRangeAsync(List<Tutorial> tutorials)
        {
            _context.Tutorials.AddRange(tutorials);
            await _context.SaveChangesAsync();
            return tutorials;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tutorial = await _context.Tutorials.FindAsync(id);
            if (tutorial != null)
            {
                _context.Tutorials.Remove(tutorial);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tutorial> FindByIdAsync(int id)
        {
            return await _context.Tutorials.FindAsync(id);
        }
    }

}
