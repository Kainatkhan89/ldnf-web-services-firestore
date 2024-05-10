using System.Collections.Generic;

namespace learndotnetfast_web_services.Model.DTOs
{
    public class CourseModulesDTO
    {
        public List<CourseModuleDTO> Modules { get; set; }

        // Default constructor to initialize the list if needed
        public CourseModulesDTO()
        {
            Modules = new List<CourseModuleDTO>();
        }
    }
}
