using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;

namespace projeSerB.Controllers
{
    public class ogrenciController : Controller
    {
        // GET: ogrenci

        projeEntities2 sb = new projeEntities2();
        [Authorize(Roles = "A,B")]
        public ActionResult Index(string p)
        {
            // var degereler = sb.ogrenci.ToList();
            //return View(degereler);
            var degerler = from s in sb.ogrenci select s;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(s => s.OgrTc.Contains(p));
            }
            return View(degerler.ToList());
        }
       
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in sb.bolumler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.BolumAd,
                                                 Value = i.Bolumid.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            List<SelectListItem> degerler1 = (from i in sb.odalar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OdaNo,
                                                 Value = i.OdaId.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr1 = degerler1;
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniOgrenci(ogrenci p1)
        {
            var ogr = sb.bolumler.Where(m => m.Bolumid == p1.bolumler.Bolumid).FirstOrDefault();            p1.bolumler = ogr;            var ogr1 = sb.odalar.Where(m => m.OdaId == p1.odalar.OdaId).FirstOrDefault();            p1.odalar = ogr1;

            sb.ogrenci.Add(p1);
            sb.SaveChanges();
            return RedirectToAction("Index");

        }
       
        public ActionResult sil(int id)
        {
            var sil = sb.ogrenci.Find(id);
            sb.ogrenci.Remove(sil);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult guncelleme_getir(int id)
        {
            var ogr = sb.ogrenci.Find(id);
            return View("guncelleme_getir", ogr);
        }
        public ActionResult Guncelle(ogrenci p1)
        {
            var ogr = sb.ogrenci.Find(p1.Ogrid);
            ogr.OgrAd = p1.OgrAd;
            ogr.OgrSoyad = p1.OgrSoyad;
            ogr.OgrTc = p1.OgrTc;
            ogr.OgrTelefon = p1.OgrTelefon;
            ogr.OgrDogum = p1.OgrDogum;
            ogr.OgrBolum = p1.OgrBolum;
            ogr.OgrMail = p1.OgrMail;
            ogr.OgrOdaNo = p1.OgrOdaNo;
            ogr.OgrVeliAdSoyad = p1.OgrVeliAdSoyad;
            ogr.OgrVeliTelefon = p1.OgrVeliTelefon;
            ogr.OgrVeliAdres = p1.OgrVeliAdres;
            sb.SaveChanges();
            return RedirectToAction("Index");

        }       
    }
}