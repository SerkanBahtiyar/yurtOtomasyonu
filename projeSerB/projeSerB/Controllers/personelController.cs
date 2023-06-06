using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
namespace projeSerB.Controllers
{
    public class personelController : Controller
    {
        // GET: personel
        projeEntities2 sb = new projeEntities2();
        public ActionResult Index()
        {
            var deger = sb.personel.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult yeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniPersonel(personel p1)
        {
            sb.personel.Add(p1);
            sb.SaveChanges();
            return View();
        }
        public ActionResult sil(int id)
        {
            var sil = sb.personel.Find(id);
            sb.personel.Remove(sil);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = sb.personel.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult guncelle(personel p1)
        {
            var prs = sb.personel.Find(p1.Personelid);
            prs.PersonelAdSoyad = p1.PersonelAdSoyad;
            prs.PersonelDepartman = p1.PersonelDepartman;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}