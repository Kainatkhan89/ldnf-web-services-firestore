using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learndotnetfast_web_services.Entities
{
    [Table("tutorials")]
    public class Tutorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ModuleId { get; set; }

        [Required]
        public int Number { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, Column("duration_seconds")]
        public int DurationSeconds { get; set; }

        [Required, MaxLength(500), Column("video_url")]
        public string VideoUrl { get; set; }

        [MaxLength(500), Column("starter_code_url")]
        public string StarterCodeUrl { get; set; }

        [MaxLength(500), Column("finished_code_url")]
        public string FinishedCodeUrl { get; set; }

        // Foreign Key reference to CourseModule
        [ForeignKey(nameof(ModuleId))]
        public CourseModule CourseModule { get; set; }
    }
}
