namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lineapreu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lineas", "preu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lineas", "preu");
        }
    }
}
