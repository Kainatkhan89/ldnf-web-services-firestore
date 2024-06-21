using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace learndotnetfast_web_services.Entities
{
    [Table("progress")]
    public class Progress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        /*// Many-to-Many relationship with Tutorials
        [Required]
        public virtual List<Tutorial> CompletedTutorials { get; set; }*/

        // Foreign key to Tutorial
        [Required]
        public int TutorialId { get; set; }
        // Navigation property to Tutorial
       // public virtual Tutorial Tutorial { get; set; }
    }

}
