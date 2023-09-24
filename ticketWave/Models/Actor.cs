using System.ComponentModel.DataAnnotations;

namespace ticketWave.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships
        public ICollection<Actor_Movie> Actors_Movies { get; set; } = new HashSet<Actor_Movie>();
    }
}
