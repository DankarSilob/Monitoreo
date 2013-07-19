using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;


namespace MvcMonitoreoTemp.Models
{
    public class GPS
    {
        [Key]
        public int idGPS { get; set; }
        public string IMEI { get; set; }
        public string nombre { get; set; }
        public string modelo { get; set; }
        public string telefono { get; set; }
        public DateTime timestamp { get; set; }
    }

}