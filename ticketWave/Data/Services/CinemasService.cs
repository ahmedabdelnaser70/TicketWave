using ticketWave.Data.Base;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
    public class CinemasService : GenericRepo<Cinema> , ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }
    }
}
