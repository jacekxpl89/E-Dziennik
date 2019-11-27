namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "User_data_FK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_data_FK", c => c.Int(nullable: false));
        }
    }
}
