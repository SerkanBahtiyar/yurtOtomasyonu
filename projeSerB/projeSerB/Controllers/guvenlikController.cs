using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
using System.Web.Security;
namespace projeSerB.Controllers
{
    public class guvenlikController : Controller
    {
        // GET: guvenlik
        projeEntities2 sb = new projeEntities2();
       
        public ActionResult girisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult girisYap(kullanici s)
        {
            var bilgiler = sb.kullanici.FirstOrDefault(b=> b.ad == s.ad && b.sifre == s.sifre);
            

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.ad, false);
                Session["ad"] = bilgiler.ad;
                return RedirectToAction("Index", "ogrenci");
            }

            else
            {
                return View();
            }
        }
        public ActionResult cikisYap()        {            FormsAuthentication.SignOut();            Session.Abandon();            return RedirectToAction("girisYap", "guvenlik");        }

    }
}