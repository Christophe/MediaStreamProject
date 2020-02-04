namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "FilmHistorique_Id", "dbo.FilmHistoriques");
            DropIndex("dbo.Films", new[] { "FilmHistorique_Id" });
            AddColumn("dbo.FilmHistoriques", "filmId", c => c.Int(nullable: false));
            AddColumn("dbo.FilmWishLists", "FilmId", c => c.Int(nullable: false));
            DropColumn("dbo.Films", "FilmHistorique_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "FilmHistorique_Id", c => c.Int());
            DropColumn("dbo.FilmWishLists", "FilmId");
            DropColumn("dbo.FilmHistoriques", "filmId");
            CreateIndex("dbo.Films", "FilmHistorique_Id");
            AddForeignKey("dbo.Films", "FilmHistorique_Id", "dbo.FilmHistoriques", "Id");
        }
    }
}
