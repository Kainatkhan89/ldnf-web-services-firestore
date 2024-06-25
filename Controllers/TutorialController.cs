using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using learndotnetfast_web_services.DTOs;
using learndotnetfast_web_services.Services.Tutorials;
using learndotnetfast_web_services.Data;

namespace learndotnetfast_web_services.Controllers
{
    [ApiController]
    [Route("api/tutorials")]
    public class TutorialController : ControllerBase
    {
        private readonly ITutorialService _tutorialService;
        private readonly DataContext _context;

        public TutorialController(DataContext context, ITutorialService tutorialService)
        {
            _context = context;
            _tutorialService = tutorialService;
        }

        [HttpGet("module/{moduleId}")]
        public async Task<ActionResult<List<TutorialDTO>>> GetTutorialsByModuleId(int moduleId)
        {
            try
            {
                var tutorials = await _tutorialService.GetTutorialsByModuleIdAsync(moduleId);
                if (tutorials == null || tutorials.Count == 0)
                {
                    return NotFound($"No tutorials found for module ID {moduleId}.");
                }
                return Ok(tutorials);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TutorialDTO>> CreateTutorial([FromBody, Required] TutorialDTO tutorialDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TutorialDTO savedTutorial = await _tutorialService.SaveTutorialAsync(tutorialDTO);
                return CreatedAtAction(nameof(GetTutorialById), new { id = savedTutorial.Id }, savedTutorial);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TutorialDTO>> GetTutorialById(int id)
        {
            try
            {
                TutorialDTO tutorial = await _tutorialService.GetTutorialByIdAsync(id);
                if (tutorial == null)
                {
                    return NotFound($"No tutorial found with ID {id}.");
                }
                return Ok(tutorial);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutorialById(int id)
        {
            try
            {
                await _tutorialService.DeleteTutorialByIdAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }
    }
}
