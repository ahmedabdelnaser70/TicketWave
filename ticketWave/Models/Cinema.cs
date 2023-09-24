using System.ComponentModel.DataAnnotations;

namespace ticketWave.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
