using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;


namespace MvcMonitoreoTemp.Models
{
    public class UnidadesListado
    {
        [Key]
        public int idUnidades { get; set; }
        public string nombreGPS { get; set; }
        public string nombre { get; set; }
    }

    public class Unidades
    {
        [Key]
        public int idUnidades { get; set; }
        public int idGPS { get; set; }
        public string nombre { get; set; }
    }
}