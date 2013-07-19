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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GPS gps)
        {
            if (ModelState.IsValid)
            {
                db.GPSs.Add(gps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gps);
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

        public ActionResult Delete(int id = 0)
        {
            GPS gps = db.GPSs.Find(id);
            if (gps == null)
            {
                return HttpNotFound();
            }
            return View(gps);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GPS gps = db.GPSs.Find(id);
            db.GPSs.Remove(gps);
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
