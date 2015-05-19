using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenDBustillo.Controllers
{
    public class ComplejoController : Controller
    {

        private db599556223afa4e37913da49d0024f159Entities _db = new db599556223afa4e37913da49d0024f159Entities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var lista = _db.Complejo.ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Complejo complejo)
        {
            _db.Complejo.Add(complejo);
            _db.SaveChanges();
            return Json(complejo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Complejo complejo)
        {
            _db.Entry(complejo).State = EntityState.Modified;
            _db.SaveChanges();
            return Json(complejo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var nId = int.Parse(id);
            var complejo = _db.Complejo.FirstOrDefault(x => x.ID == nId);
            _db.Complejo.Remove(complejo);
            _db.SaveChanges();

            return Json(complejo, JsonRequestBehavior.AllowGet);
        }



    }
}