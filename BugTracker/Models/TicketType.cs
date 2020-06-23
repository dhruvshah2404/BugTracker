using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public enum TType
    {
        Bug,
        [Display(Name = "Feature Request")]
        FeatureRequest,
        [Display(Name = "Sales Question")]
        SalesQuestion,
        [Display(Name = "How To")]
        HowTo,
        [Display(Name = "Technical Issue")]
        TechnicalIssue,
        Cancellation
    }
    public class TicketType
    {
        public TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public TType Name { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}