using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class ToonsController : ApiController
    {
        private List<ToonData> _Toons;
        public ToonsController()
        {
            var location = HttpContext.Current.Server.MapPath("/Data");
            var data = File.ReadAllText(Path.Combine(location, "Toons.json"));

            _Toons = JsonConvert.DeserializeObject<IEnumerable<ToonData>>(data).ToList();
        }

        // GET: api/Toons
        public IHttpActionResult GetToonDatas()
        {
            return Ok(_Toons);
        }

        // GET: api/Toons/5
        public IHttpActionResult GetToonData(int page, int pageSize = 25)
        {
            // paged version of the toons
            if (_Toons.Count < page * pageSize)
            {
                return NotFound();
            }

            return Ok(_Toons.Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}