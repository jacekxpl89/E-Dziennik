namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses");
            DropForeignKey("dbo.SchoolClasses", "HouseMasterId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "SchoolClassId" });
            DropIndex("dbo.Users", new[] { "SchoolClass_ID" });
            DropIndex("dbo.SchoolClasses", new[] { "HouseMasterId" });
            CreateTable(
                "dbo.Studentclasses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.ClassID })
                .ForeignKey("dbo.Users", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.SchoolClasses", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.ClassID);
            
            AlterColumn("dbo.SchoolClasses", "HouseMasterId", c => c.Int());
            CreateIndex("dbo.SchoolClasses", "HouseMasterId");
            AddForeignKey("dbo.SchoolClasses", "HouseMasterId", "dbo.Users", "UserID");
            DropColumn("dbo.Users", "SchoolClassId");
            DropColumn("dbo.Users", "SchoolClass_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SchoolClass_ID", c => c.Int());
            AddColumn("dbo.Users", "SchoolClassId", c => c.Int());
            DropForeignKey("dbo.SchoolClasses", "HouseMasterId", "dbo.Users");
            DropForeignKey("dbo.Studentclasses", "ClassID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Studentclasses", "StudentID", "dbo.Users");
            DropIndex("dbo.Studentclasses", new[] { "ClassID" });
            DropIndex("dbo.Studentclasses", new[] { "StudentID" });
            DropIndex("dbo.SchoolClasses", new[] { "HouseMasterId" });
            AlterColumn("dbo.SchoolClasses", "HouseMasterId", c => c.Int(nullable: false));
            DropTable("dbo.Studentclasses");
            CreateIndex("dbo.SchoolClasses", "HouseMasterId");
            CreateIndex("dbo.Users", "SchoolClass_ID");
            CreateIndex("dbo.Users", "SchoolClassId");
            AddForeignKey("dbo.SchoolClasses", "HouseMasterId", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses", "ID");
            AddForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
        }
    }
}
