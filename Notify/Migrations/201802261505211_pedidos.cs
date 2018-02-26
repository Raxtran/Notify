namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidoes", "fecha_actual");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "fecha_actual", c => c.DateTime(nullable: false));
        }
    }
}
