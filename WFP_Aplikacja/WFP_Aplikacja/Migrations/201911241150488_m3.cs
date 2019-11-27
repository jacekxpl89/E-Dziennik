namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User_data", "Birthday", c => c.DateTime());
            AlterColumn("dbo.User_data", "Type", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_data", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.User_data", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
