namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segunda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "precio", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "precio", c => c.Int(nullable: false));
        }
    }
}
