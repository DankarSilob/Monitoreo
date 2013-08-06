using MvcMonitoreoTemp.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            string sQuery = "select g.cve_grupo, g.nombre "+
                            "from GruposUsuarios gu "+
                            "inner join Grupos g on gu.idGrupo = g.cve_grupo "+
                            "where gu.idUsuario = {0}";
            var grupos = db.Grupos.SqlQuery(sQuery, cve_usuario);

            return View(grupos);
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Grupos/Create

        [HttpPost]
        public ActionResult Create(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupos.Add(grupo);
                db.SaveChanges();

                grupo.insertGruposUsuarios(grupo.cve_grupo, Convert.ToInt32(Session["cve_usuario"]));
                return RedirectToAction("Index");
            }

            return View(grupo);
        }

        //
        // GET: /Grupos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        //
        // POST: /Grupos/Edit/5

        [HttpPost]
        public ActionResult Edit(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupo);
        }

        //
        // GET: /Grupos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        //
        // POST: /Grupos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupos.Find(id);

            grupo.deleteGruposUsuarios(grupo.cve_grupo, Convert.ToInt32(Session["cve_usuario"]));

            db.Grupos.Remove(grupo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
