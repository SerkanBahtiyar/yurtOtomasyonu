using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
namespace projeSerB.Controllers
{
    public class giderlerController : Controller
    {
        // GET: giderler

        projeEntities2 sb = new projeEntities2();
        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var deger = sb.giderler.ToList();
            return View(deger);
        }
       [HttpGet]
       public ActionResult yeniGider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniGider(giderler p1)
        {
            sb.giderler.Add(p1);
            sb.SaveChanges();
            return View();
        }
        public ActionResult sil(int id)
        {
            var sil = sb.giderler.Find(id);
            sb.giderler.Remove(sil);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult giderGetir(int id)
        {
            var gider = sb.giderler.Find(id);
            return View("gidergetir",gider);
        }
        public ActionResult guncelle(giderler p1)
        {
            var gider = sb.giderler.Find(p1.Odemeid);
            gider.Elektrik = p1.Elektrik;
            gider.Su = p1.Su;
            gider.Dogalgaz = p1.Dogalgaz;
            gider.internet = p1.internet;
            gider.Gida = p1.Gida;
            gider.Personel = p1.Personel;
            gider.Diger = p1.Diger;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
       


    }
}