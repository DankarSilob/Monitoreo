using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;

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
        public Boolean IsValid(string _login, string _password, HttpContextBase context)
        {
            var usuario = storeDB.Usuarios.SingleOrDefault(
                c => c.login == _login
                && c.password == _password);

            if(usuario != null)
            {
                context.Session["cve_usuario"] = usuario.cve_usuario;
                context.Session["nivel"] = usuario.nivel;
                return true;
            }
            else
                return false;
        }
    }
}