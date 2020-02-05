namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "FilmId", "dbo.Films");
            DropIndex("dbo.Notes", new[] { "FilmId" });
            CreateTable(
                "dbo.FilmHistoriques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmWishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SerieHistoriques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SerieWishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "FilmHistorique_Id", c => c.Int());
            AddColumn("dbo.Films", "FilmWishList_Id", c => c.Int());
            AddColumn("dbo.Films", "SerieHistorique_Id", c => c.Int());
            AddColumn("dbo.Films", "SerieWishList_Id", c => c.Int());
            AddColumn("dbo.Notes", "ValeurNote", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "MediaId", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "NoteCompteur", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "NoteTotal", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "FilmHistorique_Id");
            CreateIndex("dbo.Films", "FilmWishList_Id");
            CreateIndex("dbo.Films", "SerieHistorique_Id");
            CreateIndex("dbo.Films", "SerieWishList_Id");
            AddForeignKey("dbo.Films", "FilmHistorique_Id", "dbo.FilmHistoriques", "Id");
            AddForeignKey("dbo.Films", "FilmWishList_Id", "dbo.FilmWishLists", "Id");
            AddForeignKey("dbo.Films", "SerieHistorique_Id", "dbo.SerieHistoriques", "Id");
            AddForeignKey("dbo.Films", "SerieWishList_Id", "dbo.SerieWishLists", "Id");
            DropColumn("dbo.Notes", "Notes");
            DropColumn("dbo.Notes", "FilmId");
            DropTable("dbo.Quizzs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumQuizz = c.Int(nullable: false),
                        NumQuestion = c.Int(nullable: false),
                        Question = c.String(),
                        RealAnswer = c.String(),
                        Answer = c.String(),
                        Theme = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "FilmId", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "Notes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Films", "SerieWishList_Id", "dbo.SerieWishLists");
            DropForeignKey("dbo.Films", "SerieHistorique_Id", "dbo.SerieHistoriques");
            DropForeignKey("dbo.Films", "FilmWishList_Id", "dbo.FilmWishLists");
            DropForeignKey("dbo.Films", "FilmHistorique_Id", "dbo.FilmHistoriques");
            DropIndex("dbo.Films", new[] { "SerieWishList_Id" });
            DropIndex("dbo.Films", new[] { "SerieHistorique_Id" });
            DropIndex("dbo.Films", new[] { "FilmWishList_Id" });
            DropIndex("dbo.Films", new[] { "FilmHistorique_Id" });
            DropColumn("dbo.Series", "NoteTotal");
            DropColumn("dbo.Series", "NoteCompteur");
            DropColumn("dbo.Notes", "MediaId");
            DropColumn("dbo.Notes", "ValeurNote");
            DropColumn("dbo.Films", "SerieWishList_Id");
            DropColumn("dbo.Films", "SerieHistorique_Id");
            DropColumn("dbo.Films", "FilmWishList_Id");
            DropColumn("dbo.Films", "FilmHistorique_Id");
            DropTable("dbo.SerieWishLists");
            DropTable("dbo.SerieHistoriques");
            DropTable("dbo.FilmWishLists");
            DropTable("dbo.FilmHistoriques");
            CreateIndex("dbo.Notes", "FilmId");
            AddForeignKey("dbo.Notes", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
        }
    }
}
