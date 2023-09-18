using System.ComponentModel.DataAnnotations.Schema;

namespace ticketWave.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        //[ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        //[ForeignKey("ActorId")]
        public Actor Actor { get; set; }

    }
}
