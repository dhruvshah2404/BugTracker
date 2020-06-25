namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MOdifiedTicketsClasses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TicketPriorities", "Name", c => c.String());
            AlterColumn("dbo.TicketStatus", "Name", c => c.String());
            AlterColumn("dbo.TicketTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TicketTypes", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.TicketStatus", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.TicketPriorities", "Name", c => c.Int(nullable: false));
        }
    }
}
