using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data;


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

        [ForeignKey("idCliente")]
        public virtual ICollection<Cliente> Clientes { get; set; }

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

        public void insertClientesUsuarios(int idCliente, int idUsuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("MonitoreoEntities");
            string sqlCommand = "dbo.sp_insertClientesUsuarios";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "idCliente", DbType.String, idCliente);
            db.AddInParameter(dbCommand, "idUsuario", DbType.String, idUsuario);
            db.ExecuteNonQuery(dbCommand);
        }

        public void insertUsuariosUsuarios(int idUsuario, int idUsuarioCreado)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("MonitoreoEntities");
            string sqlCommand = "dbo.insertUsuariosUsuarios";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "idUsuario", DbType.String, idUsuario);
            db.AddInParameter(dbCommand, "idUsuarioCreado", DbType.String, idUsuarioCreado);
            db.ExecuteNonQuery(dbCommand);
        }
    }

    public class clientes_usuarios
    {
        [Key]
        public int idClientesUsuarios { get; set; }
        public int cve_cliente { get; set; }
        public int cve_usuario { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        /*
        [ForeignKey("Clientes")] //FK_clientes_usuarios_Clientes
        public int cve_cliente { get; set; }
        [ForeignKey("Usuarios")] //FK_clientes_usuarios_Usuarios
        public int cve_usuario { get; set; }
        */
    }
}