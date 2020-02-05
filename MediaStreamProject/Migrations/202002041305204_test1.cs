namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewClassWishLists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        image = c.String(),
                        video = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewClassWishLists");
        }
    }
}
