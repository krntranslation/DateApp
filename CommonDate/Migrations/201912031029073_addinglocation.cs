namespace CommonDate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinglocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "location");
        }
    }
}
