namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "SerieHistorique_Id", "dbo.SerieHistoriques");
            DropForeignKey("dbo.Films", "SerieWishList_Id", "dbo.SerieWishLists");
            DropIndex("dbo.Films", new[] { "SerieHistorique_Id" });
            DropIndex("dbo.Films", new[] { "SerieWishList_Id" });
            AddColumn("dbo.SerieHistoriques", "FilmId", c => c.Int(nullable: false));
            AddColumn("dbo.SerieWishLists", "FilmId", c => c.Int(nullable: false));
            DropColumn("dbo.Films", "SerieHistorique_Id");
            DropColumn("dbo.Films", "SerieWishList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "SerieWishList_Id", c => c.Int());
            AddColumn("dbo.Films", "SerieHistorique_Id", c => c.Int());
            DropColumn("dbo.SerieWishLists", "FilmId");
            DropColumn("dbo.SerieHistoriques", "FilmId");
            CreateIndex("dbo.Films", "SerieWishList_Id");
            CreateIndex("dbo.Films", "SerieHistorique_Id");
            AddForeignKey("dbo.Films", "SerieWishList_Id", "dbo.SerieWishLists", "Id");
            AddForeignKey("dbo.Films", "SerieHistorique_Id", "dbo.SerieHistoriques", "Id");
        }
    }
}
