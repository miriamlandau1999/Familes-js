using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6_20.data;
using WebApplication6_20.web.Models;

namespace WebApplication6_20.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();
            FamilyDb db = new FamilyDb(Properties.Settings.Default.ConStr);
            ivm.Families = db.GetFamilies();
            return View(ivm);
        }
        public ActionResult AddFamily()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFamily(Family family)
        {
            FamilyDb db = new FamilyDb(Properties.Settings.Default.ConStr);
            db.AddFamily(family);
            return Redirect("/");
        }

    }
}