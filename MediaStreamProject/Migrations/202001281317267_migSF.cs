namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migSF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        SeasonID = c.Int(nullable: false),
                        SerieID = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        EpisodeVideo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        SerieID = c.Int(nullable: false),
                        Synopsis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.Int(nullable: false),
                        Synopsis = c.String(),
                        Note = c.Int(nullable: false),
                        Compteur = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "Genre", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "MovieVideo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "MovieVideo");
            DropColumn("dbo.Films", "Genre");
            DropTable("dbo.Series");
            DropTable("dbo.Seasons");
            DropTable("dbo.Episodes");
        }
    }
}
