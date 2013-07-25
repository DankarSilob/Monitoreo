using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MvcMonitoreoTemp.Models
{
    public class Posiciones
    {
        [Key]
        public int id { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string nombre { get; set; }
    }
}