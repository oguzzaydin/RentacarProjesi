using MS_Rentacar.BusinessLayer.Managers;
using MS_Rentacar.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MS_Rentacar.Web.Controllers
{
    public class HomeController : Controller
    {
        UrunlerManager UrunlerManager = new UrunlerManager();
        AboutManager aboutmanaer = new AboutManager();
        RulesManager rulesmanager = new RulesManager();
        ContactManager contactmanager = new ContactManager();
        SlideManager slidemanager = new SlideManager();
        MessageManager MessageManager = new MessageManager();

        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult About()
        {
            return PartialView("_About",aboutmanaer.List().FirstOrDefault());
        }
        public ActionResult Product()
        {
            return PartialView("_Products",UrunlerManager.List());
        }
        public ActionResult Contact()
        {
            return PartialView("_Contact", contactmanager.ListQueryable().FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Mesaj(GelenMesajlar model)
        {
            return new JsonResult { Data=true,JsonRequestBehavior=JsonRequestBehavior.AllowGet};
        }
        public ActionResult Slide()
        {
            return PartialView("_Slide", slidemanager.List());
        }
        public ActionResult Rules()
        {
            return PartialView("_Rules", rulesmanager.List().FirstOrDefault());
        }
    }
}