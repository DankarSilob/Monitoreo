using System;
using System.Collections.Generic;
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

    }
}
