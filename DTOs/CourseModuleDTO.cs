using System.ComponentModel.DataAnnotations;
using learndotnetfast_web_services.Common.Validators;

namespace learndotnetfast_web_services.DTOs
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
        [ValidIcon]
        public string Icon { get; set; }

        [Required, MaxLength(25)]
        [ValidColor]
        public string Color { get; set; }

        public List<TutorialDTO> Tutorials { get; set; }

       /* public override bool Equals(object obj)
        {
            if (obj is CourseModuleDTO other)
            {
                return Id == other.Id &&
                       Title == other.Title &&
                       Tutorials.SequenceEqual(other.Tutorials);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = Id.GetHashCode() ^ Title.GetHashCode();
            if (Tutorials != null)
            {
                foreach (var tutorial in Tutorials)
                {
                    hashCode ^= tutorial.GetHashCode();
                }
            }
            return hashCode;
        }*/
    }

}
