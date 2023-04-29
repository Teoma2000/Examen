using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketEstadio.Shared.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime? UseDate { get; set; }
        public bool Used { get; set; }
        public string? Entrance { get; set; }
    }
}
