using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Notify.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }

        public virtual List<Pedido> pedidosDelUsuario { get; set; } = new List<Pedido>();

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }


        public DbSet<Linea> Linea { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Pedido>()
                .HasRequired(p => p.usuario)
                .WithMany(u => u.pedidosDelUsuario)
                .Map(m => m.MapKey("usuario_id"))
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Linea>()
                .HasRequired(l => l.pedido)
                .WithMany(p => p.lineas_de_pedido)
                .HasForeignKey(l => l.id_pedido)
                .WillCascadeOnDelete(true);

            modelBuilder
                .Entity<Linea>()
                .HasRequired(l => l.producto)
                .WithMany(p => p.linias_de_pedido_donde_aparece_el_produto)
                .HasForeignKey(l => l.codigo)
                .WillCascadeOnDelete(false);



        }

    }
}