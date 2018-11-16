using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuntiLeimaus.Models;


namespace TuntiLeimaus.Controllers
{
    public class OppilasController : Controller
    {
        // GET: Oppilas
        public ActionResult Index()
        {
            ScrumEntities entities = new ScrumEntities();
            List<Tuntiraportti> model = entities.Tuntiraportti.ToList();
            entities.Dispose();

            return View(model);
        }
    }
}