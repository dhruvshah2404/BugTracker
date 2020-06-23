using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public enum TPriority
    {
        Urgent,
        Regular,
        Low
    }

    public class TicketPriority
    {
        public TicketPriority()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public TPriority Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}