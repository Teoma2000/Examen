using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEstadio.API.Data;
using TicketEstadio.Shared;

namespace TicketEstadio.API.Controllers
{
    [ApiController]
    [Route("/api/ticket")]
    public class TicketController:ControllerBase
    {

        private readonly DataContext _context;
        public TicketController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Ticket.ToListAsync());
        }



        [HttpPost]
        public async Task<ActionResult> PostAsync(Ticket ticket)
        {

            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var country = await _context.Ticket.FirstOrDefaultAsync(x => x.Id == id);
            if (country is null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Ticket ticket)
        {
            try
            {
                _context.Update(ticket);
                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un ticket con el mismo id.");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
