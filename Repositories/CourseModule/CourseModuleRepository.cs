namespace learndotnetfast_web_services.Repositories.CourseModule
{
    using System.Collections.Generic;
    using System.Linq;
    using learndotnetfast_web_services.Data;
    using learndotnetfast_web_services.Entities;
    using Microsoft.EntityFrameworkCore;

    public class CourseModuleRepository : ICourseModuleRepository
    {
        private readonly DataContext _context;

        public CourseModuleRepository(DataContext context)
        {
            _context = context;
        }

        public bool ExistsByTitle(string title)
        {
            return _context.CourseModules.Any(cm => cm.Title == title);
        }

        public bool ExistsByNumber(int number)
        {
            return _context.CourseModules.Any(cm => cm.Number == number);
        }

        public bool ExistsById(int id)
        {
            return _context.CourseModules.Any(cm => cm.Id == id);
        }

        public List<CourseModule> FindAll()
        {
            return _context.CourseModules.ToList();
        }

        public List<CourseModule> FindAllAndTheirTutorials()
        {
            return _context.CourseModules.Include(cm => cm.Tutorials).ToList();
        }

        public CourseModule FindById(int id)
        {
            return _context.CourseModules.Find(id);
        }

        public void DeleteById(int id)
        {
            var courseModule = _context.CourseModules.Find(id);
            if (courseModule != null)
            {
                _context.CourseModules.Remove(courseModule);
                _context.SaveChanges();
            }
        }

        public CourseModule Save(CourseModule courseModule)
        {
            if (courseModule.Id == 0)
            {
                _context.CourseModules.Add(courseModule);
            }
            else
            {
                _context.CourseModules.Update(courseModule);
            }
            _context.SaveChanges();
            return courseModule;
        }
    }
}
