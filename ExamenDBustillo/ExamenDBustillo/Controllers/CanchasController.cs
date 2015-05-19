using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenDBustillo.Controllers
{
    public class CanchasController : Controller
    {
        private db599556223afa4e37913da49d0024f159Entities _db = new db599556223afa4e37913da49d0024f159Entities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var lista = _db.Canchas.ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Canchas canchas)
        {
            _db.Canchas.Add(canchas);
            _db.SaveChanges();
            return Json(canchas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Canchas canchas)
        {
            _db.Entry(canchas).State = EntityState.Modified;
            _db.SaveChanges();
            return Json(canchas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var nId = int.Parse(id);
            var canchas = _db.Canchas.FirstOrDefault(x => x.ID == nId);
            _db.Canchas.Remove(canchas);
            _db.SaveChanges();

            return Json(canchas, JsonRequestBehavior.AllowGet);
        }

    }
}