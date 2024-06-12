using System.Collections.Generic;

namespace learndotnetfast_web_services.DTOs
{
    public class LearningPathDTO
    {
        public List<CourseModuleDTO> Modules { get; set; }

        // Default constructor to initialize the list if needed
        public LearningPathDTO()
        {
            Modules = new List<CourseModuleDTO>();
        }
    }
}
