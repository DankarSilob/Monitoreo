using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcMonitoreoTemp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.Usuario user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.login, user.password, this.HttpContext))
                {
                    FormsAuthentication.SetAuthCookie(user.login, false);
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
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
