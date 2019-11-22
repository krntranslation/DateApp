namespace CommonDate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSurvey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Int(nullable: false, identity: true),
                        SoccerGames = c.Boolean(nullable: false),
                        NbaGames = c.Boolean(nullable: false),
                        FootballGames = c.Boolean(nullable: false),
                        BaseballGames = c.Boolean(nullable: false),
                        MovieTheater = c.Boolean(nullable: false),
                        Bowling = c.Boolean(nullable: false),
                        Festivals = c.Boolean(nullable: false),
                        Hiking = c.Boolean(nullable: false),
                        DistilleryTour = c.Boolean(nullable: false),
                        Museums = c.Boolean(nullable: false),
                        Zoo = c.Boolean(nullable: false),
                        Dancing = c.Boolean(nullable: false),
                        MusicPop = c.Boolean(nullable: false),
                        MusicRock = c.Boolean(nullable: false),
                        MusicHipHop = c.Boolean(nullable: false),
                        MusicCountry = c.Boolean(nullable: false),
                        FoodAsian = c.Boolean(nullable: false),
                        FoodMexican = c.Boolean(nullable: false),
                        FoodItalian = c.Boolean(nullable: false),
                        FoodBurgers = c.Boolean(nullable: false),
                        FoodFineDining = c.Boolean(nullable: false),
                        FoodSteakHouse = c.Boolean(nullable: false),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.SurveyId)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "Id", "dbo.Users");
            DropIndex("dbo.Surveys", new[] { "Id" });
            DropTable("dbo.Surveys");
        }
    }
}
