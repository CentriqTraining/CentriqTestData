using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        private TrainingDAtaEntities db = new TrainingDAtaEntities();

        // GET: api/Toons
        public IHttpActionResult GetToonDatas()
        {
            return Ok( db.ToonDatas.ToList());
        }

        // GET: api/Toons/5
        public IHttpActionResult GetToonData(int page, int pageSize=25)
        {
            // paged version of the toons

            var toonData = db.ToonDatas
                .OrderBy(t => t.Studio)
                .ThenBy(t => t.Show)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList() ;
            if (toonData == null)
            {
                return NotFound();
            }

            return Ok(toonData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToonDataExists(int id)
        {
            return db.ToonDatas.Count(e => e.ID == id) > 0;
        }
    }
}