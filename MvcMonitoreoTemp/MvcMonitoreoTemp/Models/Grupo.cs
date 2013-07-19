using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcMonitoreoTemp.Models
{
    public class Grupo
    {
        [Key]
        public int cve_grupo { get; set; }
        public string nombre { get; set; }
        public int cve_usuario { get; set; }
    }
}