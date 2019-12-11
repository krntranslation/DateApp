namespace CommonDate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setGeoLatLng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "lat", c => c.Single(nullable: false));
            AddColumn("dbo.Users", "lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "lng");
            DropColumn("dbo.Users", "lat");
        }
    }
}
