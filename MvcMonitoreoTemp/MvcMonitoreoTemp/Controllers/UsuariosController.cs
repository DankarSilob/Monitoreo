using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMonitoreoTemp.Models;

namespace MvcMonitoreoTemp.Controllers
{
    public class UsuariosController : Controller
    {
        private MonitoreoEntities db = new MonitoreoEntities();

        //
        // POST: /Usuarios/Create

        public ActionResult AgregarUsuario(int id = 0)
        {
            ViewBag.idCliente = id;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUsuario(Usuario usuario, int id = 0)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                /*
                clientes_usuarios clientes_usuarios = new clientes_usuarios();
                clientes_usuarios.cve_cliente = id;
                clientes_usuarios.cve_usuario = usuario.cve_usuario;
                db.clientes_usuarios.Add(clientes_usuarios);
                db.SaveChanges();
                 */ 

                string sQuery = "INSERT INTO clientes_usuarios (cve_cliente, cve_usuario) VALUES ( 1 , 9) ";
                var usuarios = db.Usuarios.SqlQuery(sQuery);

                return RedirectToAction("UsuariosCliente", new { id = id });
            }

            return View(usuario);
        }

        public ActionResult UsuariosCliente(int id = 0)
        {
            ViewBag.idCliente = id;

            string sQuery = "select u.* " +
            "from clientes_usuarios cu " +
            "inner join usuarios u on u.cve_usuario = cu.cve_usuario " +
            "where cu.cve_cliente = {0}";
            var usuarios = db.Usuarios.SqlQuery(sQuery, id);

            return View(usuarios);
        }

        public ActionResult Index()
        {
            int searchString = Convert.ToInt32(Session["cve_usuario"]);

            var grupos = from m in db.Grupos
                         select m;

            grupos = grupos.Where(s => s.cve_usuario.Equals(searchString));

            if(grupos == null)
                return View();
            else
                return RedirectToAction("", "Grupos");
        }

        public ActionResult Clientes()
        {
            return View(db.Usuarios.ToList());
        }

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Usuarios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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