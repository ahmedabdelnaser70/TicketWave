using ticketWave.Data.Base;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
    public class ProducersService : GenericRepo<Producer> , IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
        
    }
}
