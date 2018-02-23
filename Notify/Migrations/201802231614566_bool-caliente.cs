namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolcaliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "caliente", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "caliente");
        }
    }
}
