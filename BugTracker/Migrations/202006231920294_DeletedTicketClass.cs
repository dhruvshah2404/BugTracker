namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedTicketClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "OwnerUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "TicketPriority_Id1", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "TicketPriorityId_Id", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketStatus_Id1", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketStatusId_Id", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketType_Id1", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketTypeId_Id", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            DropIndex("dbo.Tickets", new[] { "OwnerUserId" });
            DropIndex("dbo.Tickets", new[] { "AssignedUserId" });
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id1" });
            DropIndex("dbo.Tickets", new[] { "TicketPriorityId_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id1" });
            DropIndex("dbo.Tickets", new[] { "TicketStatusId_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketType_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketType_Id1" });
            DropIndex("dbo.Tickets", new[] { "TicketTypeId_Id" });
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketPriorities");
            DropTable("dbo.TicketStatus");
            DropTable("dbo.TicketTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketPriorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                        ProjectId = c.Int(nullable: false),
                        OwnerUserId = c.String(maxLength: 128),
                        AssignedUserId = c.String(maxLength: 128),
                        TicketPriority_Id = c.Int(),
                        TicketPriority_Id1 = c.Int(),
                        TicketPriorityId_Id = c.Int(),
                        TicketStatus_Id = c.Int(),
                        TicketStatus_Id1 = c.Int(),
                        TicketStatusId_Id = c.Int(),
                        TicketType_Id = c.Int(),
                        TicketType_Id1 = c.Int(),
                        TicketTypeId_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tickets", "ApplicationUser_Id");
            CreateIndex("dbo.Tickets", "TicketTypeId_Id");
            CreateIndex("dbo.Tickets", "TicketType_Id1");
            CreateIndex("dbo.Tickets", "TicketType_Id");
            CreateIndex("dbo.Tickets", "TicketStatusId_Id");
            CreateIndex("dbo.Tickets", "TicketStatus_Id1");
            CreateIndex("dbo.Tickets", "TicketStatus_Id");
            CreateIndex("dbo.Tickets", "TicketPriorityId_Id");
            CreateIndex("dbo.Tickets", "TicketPriority_Id1");
            CreateIndex("dbo.Tickets", "TicketPriority_Id");
            CreateIndex("dbo.Tickets", "AssignedUserId");
            CreateIndex("dbo.Tickets", "OwnerUserId");
            CreateIndex("dbo.Tickets", "ProjectId");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "TicketTypeId_Id", "dbo.TicketTypes", "Id");
            AddForeignKey("dbo.Tickets", "TicketType_Id1", "dbo.TicketTypes", "Id");
            AddForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes", "Id");
            AddForeignKey("dbo.Tickets", "TicketStatusId_Id", "dbo.TicketStatus", "Id");
            AddForeignKey("dbo.Tickets", "TicketStatus_Id1", "dbo.TicketStatus", "Id");
            AddForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus", "Id");
            AddForeignKey("dbo.Tickets", "TicketPriorityId_Id", "dbo.TicketPriorities", "Id");
            AddForeignKey("dbo.Tickets", "TicketPriority_Id1", "dbo.TicketPriorities", "Id");
            AddForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities", "Id");
            AddForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "OwnerUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
