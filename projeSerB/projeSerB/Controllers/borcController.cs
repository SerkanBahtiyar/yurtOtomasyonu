using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
namespace projeSerB.Controllers
{
    public class borcController : Controller
    {
        // GET: borc
        projeEntities2 sb = new projeEntities2();
        public ActionResult Index()
        {
            var deger = sb.borclar.ToList();
            return View(deger);
        }
        
       
        public ActionResult sil(int id)
        {
            var sil = sb.borclar.Find(id);
            sb.borclar.Remove(sil);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult guncelleme_getir(int id)
        {
            var ogr = sb.borclar.Find(id);
            return View("guncelleme_getir", ogr);
        }
        public ActionResult Guncelle(borclar p1)
        {
            var ogr = sb.borclar.Find(p1.OgrId);
            ogr.OgrAd = p1.OgrAd;
            ogr.OgrSoyad = p1.OgrSoyad;
            ogr.OgrKalanBorc = p1.OgrKalanBorc;
            sb.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
