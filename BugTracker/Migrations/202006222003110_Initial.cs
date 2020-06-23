namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerUserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.TicketPriorities", t => t.TicketPriority_Id)
                .ForeignKey("dbo.TicketPriorities", t => t.TicketPriority_Id1)
                .ForeignKey("dbo.TicketPriorities", t => t.TicketPriorityId_Id)
                .ForeignKey("dbo.TicketStatus", t => t.TicketStatus_Id)
                .ForeignKey("dbo.TicketStatus", t => t.TicketStatus_Id1)
                .ForeignKey("dbo.TicketStatus", t => t.TicketStatusId_Id)
                .ForeignKey("dbo.TicketTypes", t => t.TicketType_Id)
                .ForeignKey("dbo.TicketTypes", t => t.TicketType_Id1)
                .ForeignKey("dbo.TicketTypes", t => t.TicketTypeId_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ProjectId)
                .Index(t => t.OwnerUserId)
                .Index(t => t.AssignedUserId)
                .Index(t => t.TicketPriority_Id)
                .Index(t => t.TicketPriority_Id1)
                .Index(t => t.TicketPriorityId_Id)
                .Index(t => t.TicketStatus_Id)
                .Index(t => t.TicketStatus_Id1)
                .Index(t => t.TicketStatusId_Id)
                .Index(t => t.TicketType_Id)
                .Index(t => t.TicketType_Id1)
                .Index(t => t.TicketTypeId_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TicketPriorities",
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
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProjectUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "TicketTypeId_Id", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketType_Id1", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketStatusId_Id", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketStatus_Id1", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketStatus_Id", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "TicketPriorityId_Id", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "TicketPriority_Id1", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "TicketPriority_Id", "dbo.TicketPriorities");
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tickets", "OwnerUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "AssignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectUsers", "ProjectId", "dbo.Projects");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketTypeId_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketType_Id1" });
            DropIndex("dbo.Tickets", new[] { "TicketType_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketStatusId_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id1" });
            DropIndex("dbo.Tickets", new[] { "TicketStatus_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketPriorityId_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id1" });
            DropIndex("dbo.Tickets", new[] { "TicketPriority_Id" });
            DropIndex("dbo.Tickets", new[] { "AssignedUserId" });
            DropIndex("dbo.Tickets", new[] { "OwnerUserId" });
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ProjectUsers", new[] { "UserId" });
            DropIndex("dbo.ProjectUsers", new[] { "ProjectId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TicketTypes");
            DropTable("dbo.TicketStatus");
            DropTable("dbo.TicketPriorities");
            DropTable("dbo.Tickets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ProjectUsers");
            DropTable("dbo.Projects");
        }
    }
}
