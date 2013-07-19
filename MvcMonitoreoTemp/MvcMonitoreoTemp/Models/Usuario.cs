using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MvcMonitoreoTemp.Models
{
    public class Usuario
    {
        [Key]
        public int cve_usuario { get; set; }
        [Display(Name = "Usuario:")]
        public string nombre { get; set; }
        public string login { get; set; }
        [Display(Name = "Password:")]
        public string password { get; set; }
        public int nivel { get; set; }
        public DateTime fecha_registro { get; set; }

        MonitoreoEntities storeDB = new MonitoreoEntities();
        public Boolean IsValid(string _login, string _password)
        {
            var usuario = storeDB.Usuarios.SingleOrDefault(
                c => c.login == _login
                && c.password == _password);

            return usuario == null ? false : true;
        }

        public const string CartSessionKey = "cve_usuario";
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
    }

    /*
    public class MonitoreoDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
    }
    */ 
}