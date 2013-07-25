using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMonitoreoTemp.Models;

namespace MvcMonitoreoTemp.Controllers
{
    public class PosicionesController : Controller
    {
        MonitoreoEntities db = new MonitoreoEntities();

        public ActionResult Index()
        {
            string nativeSQLQuery = "SELECT top (1) * from PosicionesMapa where id = {0}";
            string name = "1";
            var emp = db.Posiciones.SqlQuery(nativeSQLQuery, name);
            return View(emp);
        }

    }
}
