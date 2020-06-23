namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTicketClass : DbMigration
    {
        public override void Up()
        {
           
            RenameColumn(table: "dbo.Tickets", name: "TicketPriority_Id", newName: "TicketPriorityId");
            RenameColumn(table: "dbo.Tickets", name: "TicketStatus_Id", newName: "TicketStatusId");
            RenameColumn(table: "dbo.Tickets", name: "TicketType_Id", newName: "TicketTypeId");
            AlterColumn("dbo.Tickets", "TicketPriorityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "TicketStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "TicketTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TicketTypeId");
            CreateIndex("dbo.Tickets", "TicketPriorityId");
            CreateIndex("dbo.Tickets", "TicketStatusId");
            AddForeignKey("dbo.Tickets", "TicketPriorityId", "dbo.TicketPriorities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes", "Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
           
        }
    }
}
