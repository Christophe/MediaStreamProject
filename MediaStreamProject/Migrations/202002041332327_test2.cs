namespace MediaStreamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NewClassWishLists");
        }
        
        public override void Down()
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
    }
}
