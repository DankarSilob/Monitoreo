using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMonitoreoTemp.Models;

namespace MvcMonitoreoTemp.Controllers
{
    public class GPSController : Controller
    {
        //
        // GET: /GPS/

        MonitoreoEntities db = new MonitoreoEntities();

        public ActionResult Index()
        {
            return View(db.GPSs.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.GPSs.Find(id));
        }

        public ActionResult Edit(int id)
        {
            GPS gps = db.GPSs.Find(id);
            if (gps == null)
            {
                return HttpNotFound();
            }
            return View(gps);
        }
        
        [HttpPost]
        public ActionResult Edit(GPS gps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gps);
        }

        public ActionResult Grupos(int id)
        {
            string sQuery = "select u.* " +
            "from ClientesUsuarios cu " +
            "inner join usuarios u on u.cve_usuario = cu.cve_usuario " +
            "where cu.idCliente = {0}";
            var gpss = db.Usuarios.SqlQuery(sQuery, id);

            return View(gpss);
        }

    


    }
}
