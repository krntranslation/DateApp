namespace CommonDate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedImagesDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Id", "dbo.Users");
            DropIndex("dbo.Images", new[] { "Id" });
            AddColumn("dbo.Users", "Title", c => c.String());
            AddColumn("dbo.Users", "ImagePath", c => c.String());
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            DropColumn("dbo.Users", "ImagePath");
            DropColumn("dbo.Users", "Title");
            CreateIndex("dbo.Images", "Id");
            AddForeignKey("dbo.Images", "Id", "dbo.Users", "Id");
        }
    }
}
