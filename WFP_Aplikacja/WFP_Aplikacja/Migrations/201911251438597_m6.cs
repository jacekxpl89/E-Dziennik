namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_data", "Premission", c => c.Int());
            DropColumn("dbo.User_data", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_data", "Type", c => c.Int());
            DropColumn("dbo.User_data", "Premission");
        }
    }
}
