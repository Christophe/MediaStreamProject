namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuizzResults", "Time", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuizzResults", "Time", c => c.String());
        }
    }
}
