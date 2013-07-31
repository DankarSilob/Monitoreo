using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonitoreoAPI.Models;

namespace MonitoreoAPI.Controllers
{
    public class PosicionesController : ApiController
    {
        //
        // GET: /Posiciones/

        APIEntities api = new APIEntities();

        public IEnumerable<PosicionesMapa> Get()
        {
            string nativeSQLQuery = "SELECT * from PosicionesMapa where 1 = {0}";
            string name = "1";
            var posiciones = api.Posiciones.SqlQuery(nativeSQLQuery, name);
            return posiciones;
        }

    }
}
