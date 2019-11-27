namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Users", new[] { "SchoolClassId" });
            AlterColumn("dbo.Users", "SchoolClassId", c => c.Int());
            CreateIndex("dbo.Users", "SchoolClassId");
            AddForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.Users", new[] { "SchoolClassId" });
            AlterColumn("dbo.Users", "SchoolClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "SchoolClassId");
            AddForeignKey("dbo.Users", "SchoolClassId", "dbo.SchoolClasses", "ID", cascadeDelete: true);
        }
    }
}
