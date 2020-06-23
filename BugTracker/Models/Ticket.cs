using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Created { get; set; } 

        [DataType(DataType.Date)]
        public DateTime? Updated { get; set; }

      
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

      
        public string OwnerUserId { get; set; }
        public virtual ApplicationUser OwnerUser { get; set; }//Submitter

     
        public string AssignedUserId { get; set; }
        public virtual ApplicationUser AssignedUser { get; set; }//Developer

        [ForeignKey("TicketType")]
        public int TicketTypeId { get; set; }
        public virtual TicketType TicketType { get; set; }//Enum

        [ForeignKey("TicketPriority")]
        public int TicketPriorityId { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }//Enum

        [ForeignKey("TicketStatus")]
        public int TicketStatusId { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }//Enum

    }
}