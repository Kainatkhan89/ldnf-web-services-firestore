using System.ComponentModel.DataAnnotations;

namespace learndotnetfast_web_services.DTOs
{
    public class ProgressDTO
    {

       // public string? Id { get; set; }
        public required string UserId { get; set; }
        public List<int>? CompletedTutorialIds { get; set; }
    }

}
