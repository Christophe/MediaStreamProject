namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.QuizzResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserLogin = c.String(),
                        Score = c.Int(nullable: false),
                        Theme = c.String(),
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
            CreateIndex("dbo.Films", "FilmHistorique_Id");
            CreateIndex("dbo.Films", "FilmWishList_Id");
            CreateIndex("dbo.Films", "SerieHistorique_Id");
            CreateIndex("dbo.Films", "SerieWishList_Id");
            AddForeignKey("dbo.Films", "FilmHistorique_Id", "dbo.FilmHistoriques", "Id");
            AddForeignKey("dbo.Films", "FilmWishList_Id", "dbo.FilmWishLists", "Id");
            AddForeignKey("dbo.Films", "SerieHistorique_Id", "dbo.SerieHistoriques", "Id");
            AddForeignKey("dbo.Films", "SerieWishList_Id", "dbo.SerieWishLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "SerieWishList_Id", "dbo.SerieWishLists");
            DropForeignKey("dbo.Films", "SerieHistorique_Id", "dbo.SerieHistoriques");
            DropForeignKey("dbo.Films", "FilmWishList_Id", "dbo.FilmWishLists");
            DropForeignKey("dbo.Films", "FilmHistorique_Id", "dbo.FilmHistoriques");
            DropIndex("dbo.Films", new[] { "SerieWishList_Id" });
            DropIndex("dbo.Films", new[] { "SerieHistorique_Id" });
            DropIndex("dbo.Films", new[] { "FilmWishList_Id" });
            DropIndex("dbo.Films", new[] { "FilmHistorique_Id" });
            DropColumn("dbo.Films", "SerieWishList_Id");
            DropColumn("dbo.Films", "SerieHistorique_Id");
            DropColumn("dbo.Films", "FilmWishList_Id");
            DropColumn("dbo.Films", "FilmHistorique_Id");
            DropTable("dbo.SerieWishLists");
            DropTable("dbo.SerieHistoriques");
            DropTable("dbo.QuizzResults");
            DropTable("dbo.FilmWishLists");
            DropTable("dbo.FilmHistoriques");
        }
    }
}
