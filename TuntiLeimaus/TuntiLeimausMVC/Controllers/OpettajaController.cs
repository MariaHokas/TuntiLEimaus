using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TuntiLeimausMVC.Models;

namespace TuntiLeimausMVC.Controllers
{
    public class OpettajaController : Controller
    {
        // GET: Opettaja
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetList()
        {
            TuntiLeimausEntities entities = new TuntiLeimausEntities();


            var model = (from c in entities.Tuntiraportti
                         select new
                         {
                             c.LeimausID,
                             c.OpiskelijaID,
                             c.Etunimi,
                             c.Sukunimi,
                             c.LuokkahuoneID,
                             c.Sisään,
                             c.Ulos
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();
            //välimuistin hallinta
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleTuntiraportti(string id)
        {
            TuntiLeimausEntities entities = new TuntiLeimausEntities();
            int LeimausID = int.Parse(id);
            var model = (from c in entities.Tuntiraportti
                         where c.LeimausID == LeimausID
                         select new
                         {
                             c.LeimausID,
                             c.OpiskelijaID,
                             c.Etunimi,
                             c.Sukunimi,
                             c.LuokkahuoneID,
                             c.Sisään,
                             c.Ulos
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Tuntiraportti tunt)
        {

            TuntiLeimausEntities entities = new TuntiLeimausEntities();
            int id = tunt.LeimausID;

            //oletetaan että tallennusoperaatio ei onnistu
            bool OK = false;

            // onko kyseessä muokkaus vai uuden lisääminen?
            //if (id.ToString() == null)
            //if (tunt.OpiskelijaID == 0)
            if (tunt.LeimausID == 0)
            {
                // kyseessä on uuden asiakkaan lisääminen, kopioidaan kentät
                Tuntiraportti dbItem = new Tuntiraportti()
                {
                    //HenkiloID = henk.HenkiloID,
                    OpiskelijaID = tunt.OpiskelijaID,
                    Etunimi = tunt.Etunimi,
                    Sukunimi = tunt.Sukunimi,
                    LuokkahuoneID = tunt.LuokkahuoneID,
                    Sisään = tunt.Sisään,
                    Ulos = tunt.Ulos
                };

                // tallennus tietokantaan
                entities.Tuntiraportti.Add(dbItem);
                entities.SaveChanges();
                OK = true;
            }
            else
            {
                //haetaan id:n perusteella rivi SQL tietokannasta       //h. muutettu c.
                Tuntiraportti dbItem = (from h in entities.Tuntiraportti
                                        where h.OpiskelijaID == tunt.OpiskelijaID
                                        select h).FirstOrDefault(); //haetaan vain yhden henkilön tiedot

                //jos tiedot löytyvät eli ei ole null
                if (dbItem != null)
                {
                    //dbItem.HenkiloID = henk.HenkiloID;  //tätä ei käytetä
                    dbItem.OpiskelijaID = tunt.OpiskelijaID;
                    dbItem.Etunimi = tunt.Etunimi;
                    dbItem.Sukunimi = tunt.Sukunimi;
                    dbItem.LuokkahuoneID = tunt.LuokkahuoneID;
                    dbItem.Sisään = tunt.Sisään;
                    dbItem.Ulos = tunt.Ulos;

                    // tallennus SQL tietokantaan
                    entities.SaveChanges();

                    //jos tallennus onnistuu
                    OK = true;
                }
            }
            //entiteettiolion vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodossa
            return Json(OK, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
        {
            TuntiLeimausEntities entities = new TuntiLeimausEntities();

            //etsitään id:n perusteella henkilöt kannasta
            //int LeimausID = int.Parse(id);
            bool OK = false;
            Tuntiraportti dbItem = (from c in entities.Tuntiraportti
                               where c.LeimausID.ToString() == id
                               select c).FirstOrDefault();

            if (dbItem != null)
            {
                //tietokannasta poisto
                entities.Tuntiraportti.Remove(dbItem);
                //tallennus SQL tietokantaan
                entities.SaveChanges();

                //jos tallennus onnistuu
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}