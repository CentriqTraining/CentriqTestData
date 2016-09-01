using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole1.Controllers
{
    public class SamplesController : Controller
    {
        // GET: Samples
        public ActionResult Chuck()
        {
            return View();
        }
        public ActionResult Toons()
        {
            return View();
        }
        public ActionResult Scooby()
        {
            return View();
        }
    }
}