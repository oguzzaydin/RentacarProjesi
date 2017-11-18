using MS_Rentacar.BusinessLayer.Managers;
using MS_Rentacar.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MS_Rentacar.Web.Controllers
{
    public class AdminController : Controller
    {

        AboutManager AboutManager = new AboutManager();
        ContactManager ContactManager = new ContactManager();
        SlideManager SlideManager = new SlideManager();
        RulesManager RulesManager = new RulesManager();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Slider()
        {
            return View(SlideManager.List());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Slider(List<bool> checkitem,List<string> checkvalue,List<HttpPostedFileBase> Resimler)
        {
            for (int i = 0; i < checkitem.Count; i++)
            {
                if(checkitem[i])
                {
                    Slider slayt = SlideManager.Find(c => c.Id==checkvalue[i]);
                    if(slayt!=null)
                    { 
                        if(SlideManager.Delete(slayt)>0)
                        { 
                        var path = HttpContext.Server.MapPath("~/Images/" + slayt.ImageUrl);
                        if(System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        }
                        else
                        {
                            TempData["isEdited"] = false;
                        }
                    }
                    else
                    {
                        TempData["isEdited"] = false;
                    }
                }

        }
            return RedirectToAction("Slider");
        }

        public ActionResult Rules()
        {
            return View(RulesManager.ListQueryable().FirstOrDefault());
        }
        public ActionResult About()
        {
            return View(AboutManager.ListQueryable().FirstOrDefault());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult About(Hakkimizda model)
        {
            if(ModelState.IsValid)
            {
              Hakkimizda hak = AboutManager.ListQueryable().FirstOrDefault();
              if(hak!=null)
                {
                    hak.Aciklama = model.Aciklama;
                    if(AboutManager.Update(hak)>0)
                    {
                        TempData["isEdited"] = true;
                        return RedirectToAction("Index");
                    }
                   
                }
                TempData["isEdited"] = false;
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Contact()
        {
            return View(ContactManager.ListQueryable().FirstOrDefault());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Contact(İletisim model)
        {
            if (ModelState.IsValid)
            {
                İletisim iletisim = ContactManager.ListQueryable().FirstOrDefault();
                if (iletisim != null)
                {
                    iletisim.Adres = model.Adres;
                    iletisim.Email1 = model.Email1;
                    iletisim.Email2 = model.Email2;
                    iletisim.Telefon1 = model.Telefon1;
                    iletisim.Telefon2 = model.Telefon2;
                    if (ContactManager.Update(iletisim) > 0)
                    {
                        TempData["isEdited"] = true;
                        return RedirectToAction("Index");
                    }
                }
                TempData["isEdited"] = false;
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult Rules(KiralamaKosullari model)
        {           
            if (ModelState.IsValid)
            {
                KiralamaKosullari kk = RulesManager.ListQueryable().FirstOrDefault();
                if (kk != null)
                {
                    kk.Aciklama = model.Aciklama;
                    if (RulesManager.Update(kk) > 0)
                    {
                        TempData["isEdited"] = true;
                        return RedirectToAction("Index");
                    }
                }
                TempData["isEdited"] = false;
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}