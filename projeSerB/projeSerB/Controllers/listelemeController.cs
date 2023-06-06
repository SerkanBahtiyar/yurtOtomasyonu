using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
namespace projeSerB.Controllers
{
    public class listelemeController : Controller
    {
        // GET: listeleme
        projeEntities2 sb = new projeEntities2();
        [AllowAnonymous]
        public ActionResult Index(string a)
        { a = "bilgisayar mühendisliği";
            List<ogrenciGetir_Result> listele = sb.ogrenciGetir(a).ToList();
            return View(listele);
        }
        public ActionResult elektrik(string a)
        {
            a = "elektrik"; 
            List<ogrenciGetir_Result> listele = sb.ogrenciGetir(a).ToList();
            return View(listele);
        }
        public ActionResult makine(string a)
        {
            a = "makine";
            List<ogrenciGetir_Result> listele = sb.ogrenciGetir(a).ToList();
            return View(listele);
        }
    }
}