namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testmigcsskhad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Notes = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId);
            
            AddColumn("dbo.Films", "Note", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "NoteCompteur", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "NoteTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "FilmId", "dbo.Films");
            DropIndex("dbo.Notes", new[] { "FilmId" });
            DropColumn("dbo.Films", "NoteTotal");
            DropColumn("dbo.Films", "NoteCompteur");
            DropColumn("dbo.Films", "Note");
            DropTable("dbo.Notes");
        }
    }
}
