using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using learndotnetfast_web_services.Services.Courses;
using learndotnetfast_web_services.Data;
using Microsoft.EntityFrameworkCore;
using learndotnetfast_web_services.DTOs;

namespace learndotnetfast_web_services.Controllers
{
    [ApiController]
    [Route("api/course-modules")]
    public class CourseModuleController : ControllerBase
    {
        private readonly ICourseModuleService _courseModuleService;
        private readonly DataContext _dataContext;

        // Constructor with dependency injection
       /* public CourseModuleController(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }*/
        public CourseModuleController(DataContext _context, ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
            _dataContext = _context;
        }

        [HttpGet]
        public async Task<ActionResult<LearningPathDTO>> GetAllCourseModules()
        {
            var courseModules = _courseModuleService.GetAllCourseModules(); 
            return Ok(courseModules);
        }

        [HttpGet("with-tutorials")]
        public ActionResult<LearningPathDTO> GetAllCourseModulesAndTheirTutorials()
        {
            var courseModules = _courseModuleService.GetAllCourseModulesAndTheirTutorials();
            return Ok(courseModules);
        }

        [HttpPost]
        public ActionResult<CourseModuleDTO> CreateCourseModule([FromBody, Required] CourseModuleDTO courseModuleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedCourseModule = _courseModuleService.SaveCourseModule(courseModuleDTO);
            return CreatedAtAction(nameof(GetCourseModuleById), new { id = savedCourseModule.Id }, savedCourseModule);
        }

        [HttpGet("{id}")]
        public ActionResult<CourseModuleDTO> GetCourseModuleById(int id)
        {
            var courseModule = _courseModuleService.GetCourseModuleById(id);
            if (courseModule == null)
            {
                return NotFound();
            }
            return Ok(courseModule);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseModuleById(int id)
        {
            _courseModuleService.DeleteCourseModuleById(id);
            return Ok();
        }
    }
}
