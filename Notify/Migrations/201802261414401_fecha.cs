namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "fecha_actual", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "fecha_actual");
        }
    }
}
