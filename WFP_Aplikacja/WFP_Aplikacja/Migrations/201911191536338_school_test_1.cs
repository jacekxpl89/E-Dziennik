namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class school_test_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mark = c.Int(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Student_ID = c.Int(),
                        Subject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Student_ID)
                .ForeignKey("dbo.Subjects", t => t.Subject_ID)
                .Index(t => t.Student_ID)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        User_data_ID = c.Int(),
                        Subject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User_data", t => t.User_data_ID)
                .ForeignKey("dbo.Subjects", t => t.Subject_ID)
                .Index(t => t.User_data_ID)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.User_data",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Street = c.String(),
                        Emile = c.String(),
                        Pesel = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Teacher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Teacher_ID)
                .Index(t => t.Teacher_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "Subject_ID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Teacher_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Subject_ID", "dbo.Subjects");
            DropForeignKey("dbo.Marks", "Student_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "User_data_ID", "dbo.User_data");
            DropIndex("dbo.Subjects", new[] { "Teacher_ID" });
            DropIndex("dbo.Users", new[] { "Subject_ID" });
            DropIndex("dbo.Users", new[] { "User_data_ID" });
            DropIndex("dbo.Marks", new[] { "Subject_ID" });
            DropIndex("dbo.Marks", new[] { "Student_ID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.User_data");
            DropTable("dbo.Users");
            DropTable("dbo.Marks");
        }
    }
}
