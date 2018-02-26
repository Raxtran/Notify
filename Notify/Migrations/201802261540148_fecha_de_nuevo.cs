namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha_de_nuevo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pedidoes", "fecha_actual");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "fecha_actual", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pedidoes", "fecha");
        }
    }
}
