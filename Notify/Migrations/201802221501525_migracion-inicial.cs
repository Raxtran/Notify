namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracioninicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lineas",
                c => new
                    {
                        id_linea = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        codigo = c.Int(nullable: false),
                        id_pedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_linea)
                .ForeignKey("dbo.Pedidoes", t => t.id_pedido, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.codigo)
                .Index(t => t.codigo)
                .Index(t => t.id_pedido);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        id_pedido = c.Int(nullable: false, identity: true),
                        usuario_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id_pedido)
                .ForeignKey("dbo.AspNetUsers", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 50),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        qtt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Lineas", "codigo", "dbo.Productoes");
            DropForeignKey("dbo.Lineas", "id_pedido", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "usuario_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Pedidoes", new[] { "usuario_id" });
            DropIndex("dbo.Lineas", new[] { "id_pedido" });
            DropIndex("dbo.Lineas", new[] { "codigo" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Productoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Lineas");
        }
    }
}
