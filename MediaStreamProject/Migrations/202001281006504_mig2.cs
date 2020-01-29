namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "MoviePicture", c => c.String());
            AlterColumn("dbo.Films", "RealName", c => c.String(nullable: false));
            DropColumn("dbo.Films", "Genre");
            DropColumn("dbo.Films", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Data", c => c.Binary());
            AddColumn("dbo.Films", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Films", "RealName", c => c.String());
            DropColumn("dbo.Films", "MoviePicture");
        }
    }
}
