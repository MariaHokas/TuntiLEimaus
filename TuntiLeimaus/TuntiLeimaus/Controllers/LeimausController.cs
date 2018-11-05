using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TuntiLeimaus.Controllers
{
    public class LeimausController : Controller
    {
        // GET: Leimaus
        public ActionResult Index()
        {
           return View();
        }
    }
}