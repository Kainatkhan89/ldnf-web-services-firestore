using learndotnetfast_web_services.DTOs;

namespace learndotnetfast_web_services.Services.Courses
{
    public interface ICourseModuleService
    {
        CourseModuleDTO SaveCourseModule(CourseModuleDTO courseModuleDTO);
        CourseModuleDTO GetCourseModuleById(int id);
        void DeleteCourseModuleById(int id);
        LearningPathDTO GetAllCourseModules();
        LearningPathDTO GetAllCourseModulesAndTheirTutorials();
    }

}
