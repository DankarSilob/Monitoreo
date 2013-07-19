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
    }
}