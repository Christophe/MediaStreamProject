namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migtestfs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Episodes", "Video", c => c.String());
            AddColumn("dbo.Films", "Image", c => c.String());
            AddColumn("dbo.Films", "Video", c => c.String());
            DropColumn("dbo.Episodes", "EpisodeVideo");
            DropColumn("dbo.Films", "MoviePicture");
            DropColumn("dbo.Films", "MovieVideo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "MovieVideo", c => c.String());
            AddColumn("dbo.Films", "MoviePicture", c => c.String());
            AddColumn("dbo.Episodes", "EpisodeVideo", c => c.String());
            DropColumn("dbo.Films", "Video");
            DropColumn("dbo.Films", "Image");
            DropColumn("dbo.Episodes", "Video");
        }
    }
}
