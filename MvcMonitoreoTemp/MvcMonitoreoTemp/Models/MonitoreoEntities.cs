using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcMonitoreoTemp.Models
{
    public class MonitoreoEntities : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<GPS> GPSs { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Posiciones> Posiciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
<<<<<<< HEAD
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<UnidadesListado> UnidadesListado { get; set; }
=======
        //public DbSet<clientes_usuarios> clientes_usuarios { get; set; }
>>>>>>> Login dependiendo del nivel de usuario
    }
}