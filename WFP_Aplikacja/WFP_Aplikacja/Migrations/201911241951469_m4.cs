namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_data", "Phone", c => c.String());
            AddColumn("dbo.User_data", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_data", "Photo");
            DropColumn("dbo.User_data", "Phone");
        }
    }
}
