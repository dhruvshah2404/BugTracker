using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class TicketComment
    {
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public string OwnerUserId { get; set; }

        public virtual ApplicationUser OwnerUser { get; set; }//Submitter
    }
}