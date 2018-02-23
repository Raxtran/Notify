namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solobebida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "beguda", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "beguda");
        }
    }
}
