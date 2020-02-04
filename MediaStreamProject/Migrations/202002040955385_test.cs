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
            AddColumn("dbo.Notes", "ValeurNote", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "MediaId", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "NoteCompteur", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "NoteTotal", c => c.Int(nullable: false));
            DropColumn("dbo.Notes", "Notes");
            DropColumn("dbo.Notes", "FilmId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "FilmId", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "Notes", c => c.Int(nullable: false));
            DropColumn("dbo.Series", "NoteTotal");
            DropColumn("dbo.Series", "NoteCompteur");
            DropColumn("dbo.Notes", "MediaId");
            DropColumn("dbo.Notes", "ValeurNote");
            CreateIndex("dbo.Notes", "FilmId");
            AddForeignKey("dbo.Notes", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
        }
    }
}
