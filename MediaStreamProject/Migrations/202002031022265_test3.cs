namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "FilmWishList_Id", "dbo.FilmWishLists");
            DropIndex("dbo.Films", new[] { "FilmWishList_Id" });
            DropColumn("dbo.Films", "FilmWishList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "FilmWishList_Id", c => c.Int());
            CreateIndex("dbo.Films", "FilmWishList_Id");
            AddForeignKey("dbo.Films", "FilmWishList_Id", "dbo.FilmWishLists", "Id");
        }
    }
}
