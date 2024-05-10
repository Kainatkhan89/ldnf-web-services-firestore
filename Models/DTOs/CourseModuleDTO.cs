using System.ComponentModel.DataAnnotations;
using learndotnetfast_web_services.Common.Validators;

namespace learndotnetfast_web_services.Model.DTOs
{
    public class CourseModuleDTO
    {
        public int? Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required, MaxLength(25)]
        [ValidIcon] // Ensure you have implemented this attribute
        public string Icon { get; set; }

        [Required, MaxLength(25)]
        [ValidColor] // Ensure you have implemented this attribute
        public string Color { get; set; }

        public List<TutorialDTO> Tutorials { get; set; }
    }

    // You will also need to define the ValidIcon and ValidColor attributes, if they're not present already.
    // Below is a simple example that can serve as a placeholder.

    public class ValidIconAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Add your validation logic here.
            return ValidationResult.Success;
        }
    }

}
