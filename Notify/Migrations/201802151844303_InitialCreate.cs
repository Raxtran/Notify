namespace Notify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lineas",
                c => new
                    {
                        id_linea = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        recibo_nombre = c.String(maxLength: 50),
                        recibo_codi = c.Int(nullable: false),
                        codigo_id_pedido = c.Int(),
                        producto_codigo = c.Int(),
                    })
                .PrimaryKey(t => t.id_linea)
                .ForeignKey("dbo.Pedidoes", t => t.codigo_id_pedido)
                .ForeignKey("dbo.Productoes", t => t.producto_codigo)
                .Index(t => t.codigo_id_pedido)
                .Index(t => t.producto_codigo);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        id_pedido = c.Int(nullable: false, identity: true),
                        codigo_linea = c.Int(nullable: false),
                        Usuario_pk = c.String(maxLength: 50),
                        user_correo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id_pedido)
                .ForeignKey("dbo.Usuarios", t => t.user_correo)
                .Index(t => t.user_correo);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        correo = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(),
                        contraseña = c.String(),
                    })
                .PrimaryKey(t => t.correo);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 50),
                        precio = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Lineas", "producto_codigo", "dbo.Productoes");
            DropForeignKey("dbo.Pedidoes", "user_correo", "dbo.Usuarios");
            DropForeignKey("dbo.Lineas", "codigo_id_pedido", "dbo.Pedidoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pedidoes", new[] { "user_correo" });
            DropIndex("dbo.Lineas", new[] { "producto_codigo" });
            DropIndex("dbo.Lineas", new[] { "codigo_id_pedido" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Productoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Lineas");
        }
    }
}
