namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m17 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Subjects", name: "SchoolClass_ID", newName: "SchoolClassId");
            RenameIndex(table: "dbo.Subjects", name: "IX_SchoolClass_ID", newName: "IX_SchoolClassId");
            AddColumn("dbo.Users", "SchoolClassId", c => c.Int());
            CreateIndex("dbo.Users", "SchoolClassId");
            AddForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Users", new[] { "SchoolClassId" });
            DropColumn("dbo.Users", "SchoolClassId");
            RenameIndex(table: "dbo.Subjects", name: "IX_SchoolClassId", newName: "IX_SchoolClass_ID");
            RenameColumn(table: "dbo.Subjects", name: "SchoolClassId", newName: "SchoolClass_ID");
        }
    }
}
