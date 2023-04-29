using TicketEstadio.Shared.Entities;
namespace Examen.API.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await TicketAsync();
        }

        private async Task TicketAsync()
        {
            if (!_context.Ticket.Any())
            {
                for (int i = 0; i < 50000; i++)
                {
                    _context.Ticket.Add(new Ticket { UseDate = null, Used = false, Entrance = null });
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
