using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
namespace projeSerB.Controllers
{
    public class bolumlerController : Controller
    {
        // GET: bolumler
         projeEntities2 sb = new projeEntities2();
        public ActionResult Index()
        {
            var deger = sb.bolumler.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult yeniBolum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniBolum(bolumler p1)
        {
            sb.bolumler.Add(p1);
            sb.SaveChanges();
            return View();
        }
        public ActionResult sil(int id)
        {
            var sil = sb.bolumler.Find(id);
            sb.bolumler.Remove(sil);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult bolumGetir(int id)
        {
            var bolum = sb.bolumler.Find(id);
            return View("bolumGetir", bolum);
        }
        public ActionResult guncelle(bolumler p1)
        {
            var bolum = sb.bolumler.Find(p1.Bolumid);
            bolum.BolumAd = p1.BolumAd;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}