using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcMonitoreoTemp.Models
{
    public class MonitoreoEntities : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<GPS> GPSs { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Posiciones> Posiciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<UnidadesListado> UnidadesListado { get; set; }
        public DbSet<clientes_usuarios> clientes_usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Usuario>()
                .HasMany(c => c.Clientes).WithMany(i => i.Usuarios)
                .Map(t => t.MapLeftKey("idCliente")
                    .MapRightKey("cve_usuario")
                    .ToTable("ClientesUsuarios"));

            /*
            modelBuilder.Entity<clientes_usuarios>()
    .HasRequired(r => r.Cliente)
    .WithMany(u => u.Usuarios);

            modelBuilder.Entity<clientes_usuarios>()
                .HasRequired(r => r.Follower)
                .WithMany();
             */ 
        }
    }
}