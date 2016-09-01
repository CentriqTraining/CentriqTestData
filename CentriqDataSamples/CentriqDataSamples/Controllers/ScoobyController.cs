using CentriqDataSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebRole1.Controllers
{
    public class ScoobyController : ApiController
    {
        // GET: api/Scooby

        List<Employee> _emps;

        public ScoobyController()
        {
            _emps = new List<Employee>() 
            {
                new Employee() { FirstName = "Scooby", LastName = "Doo", ID = 1 },
                new Employee() { FirstName = "Scrappy", LastName = "Doo", ID=2 },
                new Employee() { FirstName = "Shaggy", LastName = "Rogers", ID=3 },
                new Employee() { FirstName = "Fred", LastName = "Jones", ID=4 },
                new Employee() { FirstName = "Daphne", LastName = "Blake",ID=5 },
                new Employee() { FirstName = "Velma", LastName = "Dinkley",ID=6 },
            };

        }
        [EnableCors("*","*","*")]
        public IEnumerable<Employee> Get()
        {
            return _emps;
        }

        // GET: api/Scooby/5
        [EnableCors("*", "*", "*")]
        public IEnumerable<Employee> Get(string search)
        {
            return _emps.Where(e
                => e.FirstName.ToLower().Contains(search.ToLower())
                || e.LastName.ToLower().Contains(search.ToLower()));
        }
    }
}
