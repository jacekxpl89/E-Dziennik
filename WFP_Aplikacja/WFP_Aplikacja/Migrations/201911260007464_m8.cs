namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "ID", newName: "UserID");
            RenameColumn(table: "dbo.Subjects", name: "ID", newName: "SubjectID");
            AddColumn("dbo.Users", "User_data_FK", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "Teacher_ID1", c => c.Int());
            CreateIndex("dbo.Subjects", "Teacher_ID1");
            AddForeignKey("dbo.Subjects", "Teacher_ID1", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Teacher_ID1", "dbo.Users");
            DropIndex("dbo.Subjects", new[] { "Teacher_ID1" });
            DropColumn("dbo.Subjects", "Teacher_ID1");
            DropColumn("dbo.Users", "User_data_FK");
            RenameColumn(table: "dbo.Subjects", name: "SubjectID", newName: "ID");
            RenameColumn(table: "dbo.Users", name: "UserID", newName: "ID");
        }
    }
}
