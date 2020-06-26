namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketCommentClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        Created = c.DateTime(),
                        TicketId = c.Int(nullable: false),
                        OwnerUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerUserId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.OwnerUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketComments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketComments", "OwnerUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketComments", new[] { "OwnerUserId" });
            DropIndex("dbo.TicketComments", new[] { "TicketId" });
            DropTable("dbo.TicketComments");
        }
    }
}
