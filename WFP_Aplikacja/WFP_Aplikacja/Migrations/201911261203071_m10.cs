namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Subjects", "SchoolClass_ID", "dbo.SchoolClasses");
            DropIndex("dbo.Users", new[] { "SchoolClass_ID" });
            DropIndex("dbo.Subjects", new[] { "SchoolClass_ID" });
            RenameColumn(table: "dbo.Marks", name: "Student_ID", newName: "StudentId");
            RenameColumn(table: "dbo.Marks", name: "Subject_ID", newName: "SubjectId");
            RenameColumn(table: "dbo.Users", name: "User_data_ID", newName: "User_dataID");
            RenameColumn(table: "dbo.Subjects", name: "Teacher_ID1", newName: "TeacherId");
            RenameColumn(table: "dbo.SchoolClasses", name: "HouseMaster_ID", newName: "HouseMasterId");
            RenameIndex(table: "dbo.Marks", name: "IX_Student_ID", newName: "IX_StudentId");
            RenameIndex(table: "dbo.Marks", name: "IX_Subject_ID", newName: "IX_SubjectId");
            RenameIndex(table: "dbo.Users", name: "IX_User_data_ID", newName: "IX_User_dataID");
            RenameIndex(table: "dbo.Subjects", name: "IX_Teacher_ID1", newName: "IX_TeacherId");
            RenameIndex(table: "dbo.SchoolClasses", name: "IX_HouseMaster_ID", newName: "IX_HouseMasterId");
            DropColumn("dbo.Users", "SchoolClass_ID");
            DropColumn("dbo.Subjects", "Teacher_ID");
            DropColumn("dbo.Subjects", "SchoolClass_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "SchoolClass_ID", c => c.Int());
            AddColumn("dbo.Subjects", "Teacher_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "SchoolClass_ID", c => c.Int());
            RenameIndex(table: "dbo.SchoolClasses", name: "IX_HouseMasterId", newName: "IX_HouseMaster_ID");
            RenameIndex(table: "dbo.Subjects", name: "IX_TeacherId", newName: "IX_Teacher_ID1");
            RenameIndex(table: "dbo.Users", name: "IX_User_dataID", newName: "IX_User_data_ID");
            RenameIndex(table: "dbo.Marks", name: "IX_SubjectId", newName: "IX_Subject_ID");
            RenameIndex(table: "dbo.Marks", name: "IX_StudentId", newName: "IX_Student_ID");
            RenameColumn(table: "dbo.SchoolClasses", name: "HouseMasterId", newName: "HouseMaster_ID");
            RenameColumn(table: "dbo.Subjects", name: "TeacherId", newName: "Teacher_ID1");
            RenameColumn(table: "dbo.Users", name: "User_dataID", newName: "User_data_ID");
            RenameColumn(table: "dbo.Marks", name: "SubjectId", newName: "Subject_ID");
            RenameColumn(table: "dbo.Marks", name: "StudentId", newName: "Student_ID");
            CreateIndex("dbo.Subjects", "SchoolClass_ID");
            CreateIndex("dbo.Users", "SchoolClass_ID");
            AddForeignKey("dbo.Subjects", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
            AddForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
        }
    }
}
