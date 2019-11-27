namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Subject_ID", "dbo.Subjects");
            DropIndex("dbo.Users", new[] { "Subject_ID" });
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseMaster_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.HouseMaster_ID)
                .Index(t => t.HouseMaster_ID);
            
            AddColumn("dbo.Users", "SchoolClass_ID", c => c.Int());
            AddColumn("dbo.Subjects", "SchoolClass_ID", c => c.Int());
            CreateIndex("dbo.Users", "SchoolClass_ID");
            CreateIndex("dbo.Subjects", "SchoolClass_ID");
            AddForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
            AddForeignKey("dbo.Subjects", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
            DropColumn("dbo.Users", "Subject_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Subject_ID", c => c.Int());
            DropForeignKey("dbo.Subjects", "SchoolClass_ID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses");
            DropForeignKey("dbo.SchoolClasses", "HouseMaster_ID", "dbo.Users");
            DropIndex("dbo.SchoolClasses", new[] { "HouseMaster_ID" });
            DropIndex("dbo.Subjects", new[] { "SchoolClass_ID" });
            DropIndex("dbo.Users", new[] { "SchoolClass_ID" });
            DropColumn("dbo.Subjects", "SchoolClass_ID");
            DropColumn("dbo.Users", "SchoolClass_ID");
            DropTable("dbo.SchoolClasses");
            CreateIndex("dbo.Users", "Subject_ID");
            AddForeignKey("dbo.Users", "Subject_ID", "dbo.Subjects", "ID");
        }
    }
}
