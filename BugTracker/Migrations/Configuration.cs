namespace BugTracker.Migrations
{
    using BugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            RoleAndUserHelper.CreateUser("admin@email.com");//Admin
            RoleAndUserHelper.CreateRole("Admin");
            RoleAndUserHelper.AddRoleToUser("admin@email.com", "Admin");

            RoleAndUserHelper.CreateUser("projectManager@email.com");//PM
            RoleAndUserHelper.CreateRole("Project Manager");
            RoleAndUserHelper.AddRoleToUser("projectManager@email.com", "Project Manager");


            RoleAndUserHelper.CreateUser("developer@email.com");//Developer
            RoleAndUserHelper.CreateRole("Developer");
            RoleAndUserHelper.AddRoleToUser("developer@email.com", "Developer");

            RoleAndUserHelper.CreateUser("submitter@email.com");//Submitter
            RoleAndUserHelper.CreateRole("Submitter");
            RoleAndUserHelper.AddRoleToUser("submitter@email.com", "Submitter");

            TicketStatus ticketStatus = new TicketStatus() { Name ="Pending" };
            TicketStatus ticketStatus2 = new TicketStatus() { Name = "Assigned" };
            TicketStatus ticketStatus3 = new TicketStatus() { Name = "Updated" };
            TicketStatus ticketStatus4 = new TicketStatus() { Name = "Solved" };

            List<TicketStatus> tslist = new List<TicketStatus>() { ticketStatus, ticketStatus2, ticketStatus3, ticketStatus4 };
            foreach (var status in tslist)
            {
               
                    context.TicketStatus.Add(status);
                    context.SaveChanges();
                
            }

            TicketType ticketType = new TicketType() { Name = "Bug" };
            TicketType ticketType1 = new TicketType() { Name = "FeatureRequest" };
            TicketType ticketType2 = new TicketType() { Name ="SalesQuestion" };
            TicketType ticketType3 = new TicketType() { Name = "HowTo" };
            TicketType ticketType4 = new TicketType() { Name ="TechnicalIssue"};
            TicketType ticketType5 = new TicketType() { Name = "Cancellation" };

            List<TicketType> ttlist = new List<TicketType>() { ticketType , ticketType1, ticketType2 ,ticketType3 ,ticketType4 ,ticketType5 };
            foreach (var type in ttlist)
            {
               
                    context.TicketTypes.Add(type);
                    context.SaveChanges();
               
            }

            TicketPriority priority = new TicketPriority() { Name = "Urgent" };
            TicketPriority priority2 = new TicketPriority() { Name = "High" };
            TicketPriority priority3 = new TicketPriority() { Name = "Regular" };
            TicketPriority priority4 = new TicketPriority() { Name = "Low" };

            List<TicketPriority> priorities = new List<TicketPriority>() { priority, priority2, priority3, priority4 };
            foreach(var ticketPriority in priorities)
            {
                    context.TicketPriorities.Add(ticketPriority);
                    context.SaveChanges();
            }
        }
    }
}
