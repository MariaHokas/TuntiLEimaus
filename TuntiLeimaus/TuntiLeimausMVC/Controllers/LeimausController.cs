using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TuntiLeimausMVC.Models;

namespace TuntiLeimausMVC.Controllers
{
    public class LeimausController : Controller
    {
        public object OK { get; private set; }
        // GET: Leimaus
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult GetList()
        {

            //Tämä malli antaa enemmän mahdollisuuksia
            TuntiLeimausEntities entities = new TuntiLeimausEntities();

            var model = (from p in entities.Tuntiraportti
                         select new
                         {
                             p.LeimausID,
                             p.OpiskelijaID,
                             p.LuokkahuoneID,
                             p.Sisään,
                             p.Ulos

                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Tuntiraportti pro)
        {
            TuntiLeimausEntities entities = new TuntiLeimausEntities();
            int id = pro.LeimausID;

            bool OK = false;

            if (pro.LeimausID == 0)

            {

                // kyseessä on uuden asiakkaan lisääminen, kopioidaan kentät
                Tuntiraportti dbItem = new Tuntiraportti()
                {
                    LeimausID = pro.LeimausID,
                    OpiskelijaID = pro.OpiskelijaID,
                    LuokkahuoneID = pro.LuokkahuoneID,
                    Sisään = DateTime.Now,
                };

                // tallennus tietokantaan
                entities.Tuntiraportti.Add(dbItem);
                entities.SaveChanges();
                OK = true;
                ModelState.Clear();
            }

            entities.Dispose();
            return Json(OK, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Ulos(Tuntiraportti pro)
        {
            TuntiLeimausEntities entities = new TuntiLeimausEntities();

            //haetaan id:n perusteella rivi SQL tietokannasta

            Tuntiraportti dbItem = (from p in entities.Tuntiraportti
                                    where p.OpiskelijaID == pro.OpiskelijaID && p.LuokkahuoneID == pro.LuokkahuoneID
                                    orderby p.LeimausID descending
                                    select p).First();


            {
                //dbItem.HenkiloID = henk.HenkiloID;  //tätä ei käytetä
                //dbItem.OpiskelijaID = pro.OpiskelijaID;
                //dbItem.LuokkahuoneID = pro.LuokkahuoneID;
                dbItem.Ulos = DateTime.Now;

                // tallennus SQL tietokantaan
                //entities.Tuntiraportti.Add(dbItem);
                entities.SaveChanges();
                OK = true;
                ModelState.Clear();
            }

            //entiteettiolion vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodossa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }

    }
}