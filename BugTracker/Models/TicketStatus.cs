using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public enum TStatus
    {
       Pending,
       Assigned,
       Updated,
       Completed
    }
    public class TicketStatus
    {
        public TicketStatus()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public TStatus Name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}