using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ticketWave.Data.Enums;

namespace ticketWave.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public ICollection<Actor_Movie> Actors_Movies { get; set; } = new HashSet<Actor_Movie>();

        //Cinema
        public int CinemaId { get; set; }
        //[ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        //[ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
