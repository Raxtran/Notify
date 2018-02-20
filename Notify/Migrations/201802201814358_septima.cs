namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class septima : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "qtt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "qtt");
        }
    }
}
