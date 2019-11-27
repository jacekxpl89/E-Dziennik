namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_from_ID = c.Int(),
                        User_to_ID = c.Int(),
                        Title = c.String(),
                        Context = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_from_ID)
                .ForeignKey("dbo.Users", t => t.User_to_ID)
                .Index(t => t.User_from_ID)
                .Index(t => t.User_to_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_to_ID", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_from_ID", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "User_to_ID" });
            DropIndex("dbo.Messages", new[] { "User_from_ID" });
            DropTable("dbo.Messages");
        }
    }
}
