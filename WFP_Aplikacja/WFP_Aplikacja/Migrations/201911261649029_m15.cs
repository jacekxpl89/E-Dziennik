namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SchoolClass_ID", c => c.Int());
            AddColumn("dbo.Subjects", "SchoolClass_ID", c => c.Int());
            CreateIndex("dbo.Users", "SchoolClass_ID");
            CreateIndex("dbo.Subjects", "SchoolClass_ID");
            AddForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
            AddForeignKey("dbo.Subjects", "SchoolClass_ID", "dbo.SchoolClasses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "SchoolClass_ID", "dbo.SchoolClasses");
            DropForeignKey("dbo.Users", "SchoolClass_ID", "dbo.SchoolClasses");
            DropIndex("dbo.Subjects", new[] { "SchoolClass_ID" });
            DropIndex("dbo.Users", new[] { "SchoolClass_ID" });
            DropColumn("dbo.Subjects", "SchoolClass_ID");
            DropColumn("dbo.Users", "SchoolClass_ID");
        }
    }
}
