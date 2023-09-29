using ticketWave.Data.Base;
using ticketWave.Data.ViewModels;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
    public interface IMoviesService : IGenericRepo<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
    }
}
