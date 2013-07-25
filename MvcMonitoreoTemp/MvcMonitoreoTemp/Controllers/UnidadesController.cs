using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMonitoreoTemp.Models;

namespace MvcMonitoreoTemp.Controllers
{
    public class UnidadesController : Controller
    {
        MonitoreoEntities db = new MonitoreoEntities();

        public ActionResult Index()
        {
            string nativeSQLQuery = "select idUnidades, g.nombre as nombreGPS, u.nombre From unidades u inner join gps g on g.idGPS = u.idGPS where 1 = {0}";
            string name = "1";
            var emp = db.UnidadesListado.SqlQuery(nativeSQLQuery, name);
            return View(emp);
        }

        public ActionResult Create()
        {
            GPS gps = new GPS();
            var gpsModel = db.GPSs.ToList();
            SelectList gpss = new SelectList(gpsModel, "idGPS", "nombre");
            ViewBag.gps = gpss;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Unidades unidad)
        {
            if (ModelState.IsValid)
            {
                db.Unidades.Add(unidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidad);
        }

        public ActionResult Edit(int id)
        {
            Unidades unidad = db.Unidades.Find(id);
            GPS gps = new GPS();
            var gpsModel = db.GPSs.ToList();
            SelectList gpss = new SelectList(gpsModel, "idGPS", "nombre");
            ViewBag.gps = gpss;
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        [HttpPost]
        public ActionResult Edit(Unidades unidad)
        {
            if (ModelState.IsValid)
            {
                GPS gps = new GPS();
                var gpsModel = db.GPSs.ToList();
                SelectList gpss = new SelectList(gpsModel, "idGPS", "nombre");
                ViewBag.gps = gpss;
                db.Entry(unidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidad);
        }

        public ActionResult Delete(int id = 0)
        {
            Unidades unidad = db.Unidades.Find(id);
            GPS gps = new GPS();
            var gpsModel = db.GPSs.ToList();
            SelectList gpss = new SelectList(gpsModel, "idGPS", "nombre");
            ViewBag.gps = gpss;
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidades  unidad = db.Unidades.Find(id);
            db.Unidades.Remove(unidad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
