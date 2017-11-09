namespace QBox.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 500, unicode: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.GameQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        AnswerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answer", t => t.AnswerId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.Game", t => t.GameId)
                .Index(t => t.GameId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Highscore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ScorePercent = c.Double(nullable: false),
                        TimeElapsedSeconds = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        EndTime = c.DateTime(nullable: false),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameQuestion", "GameId", "dbo.Game");
            DropForeignKey("dbo.Question", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.GameQuestion", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Highscore", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Game", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.GameQuestion", "AnswerId", "dbo.Answer");
            DropIndex("dbo.Question", new[] { "CategoryId" });
            DropIndex("dbo.Highscore", new[] { "CategoryId" });
            DropIndex("dbo.Game", new[] { "CategoryId" });
            DropIndex("dbo.GameQuestion", new[] { "AnswerId" });
            DropIndex("dbo.GameQuestion", new[] { "QuestionId" });
            DropIndex("dbo.GameQuestion", new[] { "GameId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.Question");
            DropTable("dbo.Highscore");
            DropTable("dbo.Category");
            DropTable("dbo.Game");
            DropTable("dbo.GameQuestion");
            DropTable("dbo.Answer");
        }
    }
}
