using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace BugTracker.Models
{
    public static class TicketHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();// the database

       
        public static void Create(string Title,string Description,int ticketTypeId,int priorityId)
        {
            Ticket ticket = new Ticket() { Title = Title, Description = Description, TicketTypeId = ticketTypeId, TicketPriorityId = priorityId };
            ticket.Created = DateTime.Now;
            ticket.OwnerUserId= HttpContext.Current.User.Identity.GetUserId();
            ticket.TicketStatusId = db.TicketStatus.FirstOrDefault(t => t.Name == "Pending").Id;
            db.Tickets.Add(ticket);

            db.SaveChanges();
        }

        public static bool AssignTicketToDeveloper(int ticketId, string userId)
        {
            var ticket = db.Tickets.Find(ticketId);
            var user = db.Users.Find(userId);

            if (!user.Tickets.Contains(ticket))
            {
                user.Tickets.Add(ticket);
                ticket.AssignedUser = user;
                ticket.AssignedUserId = userId;

                return true;
            }

            return false;
        }
    }


    
}