using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Project
    {
        public Project()
        {
            Users = new HashSet<ProjectUser>();
            Tickets = new HashSet<Ticket>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ProjectUser> Users { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}