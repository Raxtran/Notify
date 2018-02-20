namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sexta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "precio", c => c.Single(nullable: false));
        }
    }
}
