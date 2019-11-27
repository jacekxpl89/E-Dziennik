namespace WFP_Aplikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolClasses", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolClasses", "Name");
        }
    }
}
