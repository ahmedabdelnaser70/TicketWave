using Microsoft.EntityFrameworkCore;
using ticketWave.Data.Base;
using ticketWave.Data.ViewModels;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
    public class MoviesService : GenericRepo<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var data = new NewMovieDropdownsVM()
            {
                Producers = await _context.Producers.OrderBy(c => c.FullName).ToListAsync(),
                Actors = await _context.Actors.OrderBy(c => c.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync(),
            };
            return data;
        }
    }
}
