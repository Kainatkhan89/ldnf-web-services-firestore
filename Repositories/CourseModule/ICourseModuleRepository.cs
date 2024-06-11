namespace learndotnetfast_web_services.Repositories.CourseModule
{
    using System.Collections.Generic;
    using learndotnetfast_web_services.Entities;

    public interface ICourseModuleRepository
    {
        bool ExistsByTitle(string title);
        bool ExistsByNumber(int number);
        bool ExistsById(int id);
        List<CourseModule> FindAll();
        List<CourseModule> FindAllAndTheirTutorials();
        CourseModule FindById(int id);
        void DeleteById(int id);
        CourseModule Save(CourseModule courseModule);
    }

}
