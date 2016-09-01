using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CentriqDataSamples.Models;
using System.Web.Http.Cors;

namespace CentriqDataSamples.Controllers
{
    public class ChuckController : ApiController
    {
        private BuyMoria db;
        public ChuckController()
        {
            db = new BuyMoria();
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Chuck
        [EnableCors("*", "*", "*")]
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/Chuck/5
        [EnableCors("*", "*", "GET")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.ID == id) > 0;
        }
    }
}