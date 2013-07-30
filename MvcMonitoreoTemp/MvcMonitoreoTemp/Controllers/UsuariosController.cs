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
                usuario = db.Usuarios.Add(usuario);
                db.SaveChanges();

                usuario.insertClientesUsuarios(id, usuario.cve_usuario);

                /*
                Cliente cliente = db.Clientes.Find(id);
                List<Cliente> list = new List<Cliente>();
                list.Add(cliente);

                usuario.Clientes = list;

                usuario = db.Usuarios.Add(usuario);
                db.SaveChanges();
                */

                return RedirectToAction("UsuariosCliente", new { id = id });
            }

            return View(usuario);
        }

        public ActionResult UsuariosCliente(int id = 0)
        {
            ViewBag.idCliente = id;

            string sQuery = "select u.* " +
            "from ClientesUsuarios cu " +
            "inner join usuarios u on u.cve_usuario = cu.cve_usuario " +
            "where cu.idCliente = {0}";
            var usuarios = db.Usuarios.SqlQuery(sQuery, id);

            return View(usuarios);
        }

        public ActionResult Index()
        {
            /*
            switch (Convert.ToInt32(Session["nivel"]))
            {
                case 1: //WEBMASTER
                    return RedirectToAction("", "Clientes");
                    break;
                case 2: //ADMINISTRADOR
                    return RedirectToAction("Clientes", "Usuarios");
                    break;
                case 3: //MONITOREO
                    return RedirectToAction("", "Posiciones");
                    break;
            }
             * */

            switch (Convert.ToInt32(Session["nivel"]))
            {
                case 1: //WEBMASTER
                    return RedirectToAction("Clientes");
                    break;
                case 2: //ADMINISTRADOR
                    return RedirectToAction("Administrador", "Usuarios");
                    break;
                case 3: //MONITOREO
                    return RedirectToAction("", "Posiciones");
                    break;
            }

            return View();
        }

        /*
        public SelectList GetCountrySelectList()
        {
            int nivel = ViewBag.nivel;

            string sQuery = "select u.* " +
            "from Usuarios u " +
            "where u.nivel = {0}";
            var usuarios = db.Usuarios.SqlQuery(sQuery, nivel);

            return View(usuarios);
            return new SelectList(countries.ToArray(),
                    "Code",
                    "Name");




            var countries = Country.GetCountries();
            return new SelectList(countries.ToArray(),
                                "Code",
                                "Name");

        }

        public ActionResult UsuariosDDL()
        {
            ViewBag.Country = GetCountrySelectList();
            return View();
        }
        */

        public ActionResult Clientes()
        {
            return View(db.Usuarios.ToList());
        }

        public ActionResult Administrador()
        {
            int cve_usuario = Convert.ToInt32(Session["cve_usuario"]);

            string sQuery = "select u.* from UsuariosUsuarios uu "+
                            "inner join Usuarios u on u.cve_usuario = uu.cve_usuario_creado "+
                            "where uu.cve_usuario = {0}";
            var usuarios = db.Usuarios.SqlQuery(sQuery, cve_usuario);

            return View(usuarios);
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

        public ActionResult Agregar(int nivel = 0)
        {
            ViewBag.nivel = nivel;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                usuario.insertUsuariosUsuarios(Convert.ToInt32(Session["cve_usuario"]), usuario.cve_usuario);
                return RedirectToAction("Administrador");
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

                switch (Convert.ToInt32(Session["nivel"]))
                {
                    case 1: //WEBMASTER
                        return RedirectToAction("", "Clientes");
                        break;
                    case 2: //ADMINISTRADOR
                        return RedirectToAction("Administrador", "Usuarios");
                        break;
                    case 3: //MONITOREO
                        return RedirectToAction("", "Posiciones");
                        break;
                }

                //return RedirectToAction("Index");
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