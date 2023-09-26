using System.ComponentModel.DataAnnotations;
using ticketWave.Data.Base;

namespace ticketWave.Models
{
    public class Cinema : BaseEntity
    {
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 20 chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }

        //Relationships
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
