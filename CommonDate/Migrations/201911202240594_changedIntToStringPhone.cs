namespace CommonDate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedIntToStringPhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
