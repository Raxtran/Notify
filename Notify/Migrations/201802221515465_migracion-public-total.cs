namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionpublictotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "total");
        }
    }
}
