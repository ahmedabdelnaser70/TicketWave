using ticketWave.Data.Base;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
   public class ActorsService : GenericRepo<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
