using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MonitoreoAPI.Models
{
    public class APIEntities : DbContext
    {
        public DbSet<PosicionesMapa> Posiciones { get; set; }
    }
}