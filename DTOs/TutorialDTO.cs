using System.ComponentModel.DataAnnotations;

namespace learndotnetfast_web_services.DTOs
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
        public string VideoUrl { get; set; }

        public string StarterCodeUrl { get; set; }

        public string FinishedCodeUrl { get; set; }
    }
}
