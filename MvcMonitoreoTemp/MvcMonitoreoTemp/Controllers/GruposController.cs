using MvcMonitoreoTemp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMonitoreoTemp.Controllers
{
    public class GruposController : Controller
    {
        private MonitoreoEntities db = new MonitoreoEntities();
        //
        // GET: /Grupos/

        public ActionResult Index()
        {
            int cve_usuario = Convert.ToInt32(Session["cve_usuario"]);

            string sQuery = "SELECT * FROM dbo.Grupos WHERE cve_usuario = {0}";
            var grupos = db.Grupos.SqlQuery(sQuery, cve_usuario);

            return View(grupos);
        }

    }
}
