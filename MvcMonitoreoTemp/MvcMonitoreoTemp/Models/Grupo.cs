using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data;

namespace MvcMonitoreoTemp.Models
{
    [Table("Grupos")]
    public class Grupo
    {
        [Key]
        public int cve_grupo { get; set; }
        public string nombre { get; set; }
        //public int cve_usuario { get; set; }

        public void insertGruposUsuarios(int idGrupo, int idUsuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("MonitoreoEntities");
            string sqlCommand = "dbo.sp_insertGruposUsuarios";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "idGrupo", DbType.String, idGrupo);
            db.AddInParameter(dbCommand, "idUsuario", DbType.String, idUsuario);
            db.ExecuteNonQuery(dbCommand);
        }

        public void deleteGruposUsuarios(int idGrupo, int idUsuario)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase("MonitoreoEntities");
            string sqlCommand = "dbo.sp_deleteGruposUsuarios";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "idGrupo", DbType.String, idGrupo);
            db.AddInParameter(dbCommand, "idUsuario", DbType.String, idUsuario);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}