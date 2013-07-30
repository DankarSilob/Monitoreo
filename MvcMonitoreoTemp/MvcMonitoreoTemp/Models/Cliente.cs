using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMonitoreoTemp.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string contacto { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_registro { get; set; }
        [ForeignKey("cve_usuario")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}