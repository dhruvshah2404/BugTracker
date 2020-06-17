namespace BugTracker.Migrations
{
    using BugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
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

        }
    }
}
