using learndotnetfast_web_services.DTOs;
using learndotnetfast_web_services.Services.Progress;
using Microsoft.AspNetCore.Mvc;

namespace learndotnetfast_web_services.Controllers
{
    [ApiController]
    [Route("api/progress")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ProgressDTO>> GetProgress(string userId)
        {
            var progress = await _progressService.GetProgressByUserIdAsync(userId);
            if (progress == null)
                return NotFound($"Progress for user ID {userId} not found.");

            return Ok(progress);
        }

        [HttpPost("complete-tutorial")]
        public async Task<ActionResult<TutorialCompletionDTO>> CompleteTutorial([FromBody] TutorialCompletionDTO completionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedProgress = await _progressService.AddCompletedTutorialAsync(completionDTO);
                return CreatedAtAction(nameof(GetProgress), new { userId = completionDTO.UserId }, updatedProgress);
                //return Ok(updatedProgress);
            }
            catch (Exception ex)
            {
                // Log the exception details here to understand the failure
                return StatusCode(500, "An error occurred while completing the tutorial.");
            }
        }

        [HttpDelete("remove-completion")]
        public async Task<ActionResult> DeleteCompletedTutorial([FromBody] TutorialCompletionDTO completionDTO)
        {
            try
            {
                await _progressService.RemoveCompletedTutorialAsync(completionDTO);
                return NoContent();  // HTTP 204 as response for successful delete with no content to return
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("remove-all/{userId}")]
        public async Task<ActionResult> DeleteAllProgressForUser(string userId)
        {
            try
            {
                await _progressService.RemoveAllProgressForUserAsync(userId);
                return NoContent(); // HTTP 204 as response for successful delete with no content to return
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


    }

}
