namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Teacher_ID", "dbo.Users");
            DropIndex("dbo.Subjects", new[] { "Teacher_ID" });
            AlterColumn("dbo.Subjects", "Teacher_ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Teacher_ID", c => c.Int());
            CreateIndex("dbo.Subjects", "Teacher_ID");
            AddForeignKey("dbo.Subjects", "Teacher_ID", "dbo.Users", "ID");
        }
    }
}
