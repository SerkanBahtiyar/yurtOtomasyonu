using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeSerB.Models.Entity;
namespace projeSerB.Controllers
{
    public class odaController : Controller
    {
        // GET: oda
        projeEntities2 sb = new projeEntities2();
        public ActionResult Index()
        {
            var deger = sb.odalar.ToList();
            return View(deger);
        }
    }
}