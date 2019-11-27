namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Studentclasses", "StudentID", "dbo.Users");
            DropForeignKey("dbo.Studentclasses", "ClassID", "dbo.SchoolClasses");
            DropIndex("dbo.Studentclasses", new[] { "StudentID" });
            DropIndex("dbo.Studentclasses", new[] { "ClassID" });
            AddColumn("dbo.Users", "SchoolClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "SchoolClassId");
            AddForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses", "ID", cascadeDelete: true);
            DropTable("dbo.Studentclasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Studentclasses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.ClassID });
            
            DropForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Users", new[] { "SchoolClassId" });
            DropColumn("dbo.Users", "SchoolClassId");
            CreateIndex("dbo.Studentclasses", "ClassID");
            CreateIndex("dbo.Studentclasses", "StudentID");
            AddForeignKey("dbo.Studentclasses", "ClassID", "dbo.SchoolClasses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Studentclasses", "StudentID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
