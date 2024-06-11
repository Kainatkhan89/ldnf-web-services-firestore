using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using learndotnetfast_web_services.Common.Enums;
using learndotnetfast_web_services.Entities;

namespace learndotnetfast_web_services.Entities
{
    [Table("course_modules")]
    public class CourseModule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        // One-to-Many relationship with Tutorials
        public List<Tutorial> Tutorials { get; set; } = new List<Tutorial>();

        [Required, MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public Icon Icon { get; set; }

        [Required, MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public Color Color { get; set; }
    }
}
