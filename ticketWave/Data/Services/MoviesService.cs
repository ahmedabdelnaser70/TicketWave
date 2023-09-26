using ticketWave.Data.Base;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
    public class MoviesService : GenericRepo<Movie> , IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }
    }
}
