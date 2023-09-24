using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ticketWave.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]

        public string Bio { get; set; }

        //Relationships
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
