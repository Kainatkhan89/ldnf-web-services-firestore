using System.ComponentModel.DataAnnotations;

namespace learndotnetfast_web_services.Model.DTOs
{
    public class TutorialDTO
    {
        public int? Id { get; set; }

        [Required]
        public int ModuleId { get; set; }

        [Required]
        public int Number { get; set; }

        [Required, MinLength(1)]
        public string Title { get; set; }

        [Required]
        public int DurationSeconds { get; set; }

        [Required, MinLength(1)]
        [Url] // Ensures that the string is a valid URL format
        public string VideoUrl { get; set; }

        [Url] // Optional URL validation
        public string StarterCodeUrl { get; set; }

        [Url] // Optional URL validation
        public string FinishedCodeUrl { get; set; }
    }
}
