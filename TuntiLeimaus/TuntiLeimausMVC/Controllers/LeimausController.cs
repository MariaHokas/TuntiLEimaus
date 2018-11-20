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
        // GET: Leimaus
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult GetList()
        {

            //Tämä malli antaa enemmän mahdollisuuksia
            TuntiLeimausEntities entities = new TuntiLeimausEntities();

            var model = (from p in entities.Leimaus
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
        public JsonResult GetSingLeimaus(int id)
        {

            //Tämä malli antaa enemmän mahdollisuuksia
            TuntiLeimausEntities entities = new TuntiLeimausEntities();
            //List<Customer> model = entities.Customers.ToList();
            var model = (from p in entities.Leimaus
                         where p.LeimausID == id
                         select new
                         {
                             p.LeimausID,
                             p.OpiskelijaID,
                             p.LuokkahuoneID,
                             p.Sisään,
                             p.Ulos
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Leimaus pro)
        {
            TuntiLeimausEntities entities = new TuntiLeimausEntities();
            int id = pro.LeimausID;

            bool OK = false;

            if (pro.LeimausID == 0)

            {

                // kyseessä on uuden asiakkaan lisääminen, kopioidaan kentät
                Leimaus dbItem = new Leimaus()
                {
                    LeimausID = pro.LeimausID,
                    OpiskelijaID = pro.OpiskelijaID,
                    LuokkahuoneID = pro.LuokkahuoneID,
                    Sisään = DateTime.Now,
                    Ulos = pro.Ulos

                };

                // tallennus tietokantaan
                entities.Leimaus.Add(dbItem);
                entities.SaveChanges();
                OK = true;
            }
            else
            //tästä ehkä lähdetty muokkaamaan.
            {
                // muokkaus, haetaan id:n perusteella riviä tietokannasta

                Leimaus dbItem = (from t in entities.Leimaus
                                  where t.LeimausID == id
                                  select t).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem.LeimausID = pro.LeimausID;
                    dbItem.OpiskelijaID = pro.OpiskelijaID;
                    dbItem.LuokkahuoneID = pro.LuokkahuoneID;
                    dbItem.Sisään = pro.Sisään;
                    dbItem.Ulos = DateTime.Now;

                    // tallennus tietokantaan
                    entities.SaveChanges();
                    OK = true;
                }
            }
            entities.Dispose();
            return Json(OK, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index2()
        {
            return View();

        }

    }
}