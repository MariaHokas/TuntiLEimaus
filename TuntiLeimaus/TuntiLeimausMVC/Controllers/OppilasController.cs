using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuntiLeimausMVC.Models;

namespace TuntiLeimausMVC.Controllers
{
    public class OppilasController : Controller
    {
        // GET: Oppilas
        public ActionResult Index()
        {

            TuntiLeimausEntities entities = new TuntiLeimausEntities();
            List<Tuntiraportti> model = entities.Tuntiraportti.ToList();
            entities.Dispose();

            return View(model);
        }
    }
}