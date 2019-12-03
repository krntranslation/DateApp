namespace CommonDate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        eventName = c.String(),
                        eventDate = c.DateTime(nullable: false),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Id", "dbo.Users");
            DropIndex("dbo.Events", new[] { "Id" });
            DropTable("dbo.Events");
        }
    }
}
