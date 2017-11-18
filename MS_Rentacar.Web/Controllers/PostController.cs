using MS_Rentacar.BusinessLayer.Managers;
using MS_Rentacar.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using MS_Rentacar.Web.Models;
using MS_Rentacar.Web.Models.MessageViewModels;

namespace MS_Rentacar.Web.Controllers
{
    public class PostController : Controller
    {
        private UrunlerManager urunmanager = new UrunlerManager();
        private ImagesManager ImageManager = new ImagesManager();
        private List<Images> ConvertFileToImages(List<HttpPostedFileBase> Resimler,Urunler urun)
        {
            List<Images> list = new List<Images>();
            if (Resimler.Count>0&&Resimler[0]!=null)
            {
                foreach (var item in Resimler)
                {
                    list.Add(new Images
                    {
                        Id = Guid.NewGuid().ToString(),
                        ImageUrl = item.FileName,
                        Urun = urun
                    });
                }
            }
            return list;
        }
        private List<Images> ConvertFileToImages(List<HttpPostedFileBase> Resimler, string urunid)
        {
            List<Images> list = new List<Images>();
            Urunler urun = urunmanager.Find(c => c.Id == urunid);
            if(Resimler.Count>0&&Resimler[0]!=null)
            { 
            foreach (var item in Resimler)
            {
                list.Add(new Images
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageUrl = item.FileName,
                    Urun = urun
                });
            }
            }
            return list;
        }

        public ActionResult Index()
        {
            return View(urunmanager.ListQueryable().Include(c=>c.Images).ToList());
        }
        public ActionResult Create()
        {
            return View(new Urunler());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Urunler model,List<HttpPostedFileBase> Resimler)
        {
            if (ModelState.IsValid)
            {
                Urunler urun = new Urunler()
                {
                    Id=Guid.NewGuid().ToString(),
                    Aciklama=model.Aciklama,
                    EklenmeTarihi=DateTime.Now,
                    Marka=model.Marka,
                    Model=model.Model
                };
                if(Resimler.Count>0&&Resimler[0]!=null)
                { 
                       urun.Images = ConvertFileToImages(Resimler,urun);
                }
                if (model == null)
                {
                    ErrorViewModel<Urunler> errormodel = new ErrorViewModel<Urunler>() { Result=new Urunler(),Message="Ürün eklenirken bir hata oluştu." };
                    return RedirectToAction("NotFound");
                }
                if (urunmanager.Insert(urun) > 0)
                {
                    for (int i = 0; i < Resimler.Count; i++)
                    {
                        if (Resimler[i] != null)
                        { 
                            Resimler[i].SaveAs(HttpContext.Server.MapPath("~/Images/" + Resimler[i].FileName));
                        }
                    }
                    TempData["isEdited"] = true;
                }
                else
                {
                    ModelState.AddModelError("","İşlem yapılırken bir hata oluştu!");
                    TempData["isEdited"] = false;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            UrunlerViewModel model = new UrunlerViewModel()
            {
                Urun = urunmanager.ListQueryable().Include(c=>c.Images).FirstOrDefault(c => c.Id == id),
                
            };
            if(model==null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult Edit(UrunlerViewModel model)
        {
            Urunler urun = urunmanager.Find(c => c.Id == model.Urun.Id);
            if (urun == null)
            {
                ErrorViewModel<Urunler> ErrorViewModel = new ErrorViewModel<Urunler>() { Result = new Urunler(), Message = "Ürün güncellenirken hata oluştu." };
                return View("ErrorPage", ErrorViewModel);
            }
            if (ModelState.IsValid)
            {
                // İşlem sırası
                //Ürünü veritabanından çekme (Kontrol amaçlı)
                //Ürüne eklenmiş olan resimleri ürünün ımages listesine eklemek CovertFileToImages ile...
                //Formda işaretlenmemiş olan resimleri tekrar images nesnesine ekliyoruz (silinmemesi için)
                //ürün bilgileri güncelleniyor
                //ürün BusinessLayer Update metoduna gönderiliyor
                if (model.Resim_Upload[0] != null && model.Resim_Upload.Count > 0)
                {
                    urun.Images = ConvertFileToImages(model.Resim_Upload, urun.Id); // dosyalar geri dönüşü List<Images> olan fonksiyona  gönderiliyor  fonksiyon en üstte yer almakta 2 parametrelidir 
                }
                for (int i= 0;i<model._ischeck.Count;i++)
                {
                    string id = model._checkvalue[i];//hidden inputtan gelen id değeri
                    Images image = ImageManager.Find(c => c.Id == id);
                    if (model._ischeck[i])
                    {
                        if (image==null||!(ImageManager.Delete(image)>0))//if sorgusunda kısa devre var eğer nullsa delete işlemini hiç yapmayacak (operator || yada olduğu için)
                        {
                            ModelState.AddModelError("", "Resimler silinirken bir hata oluştu.Tekrar deneyin.....");
                            return View(model);
                        }
                        else
                        {
                                var path = HttpContext.Server.MapPath("~/Images/" +image.ImageUrl);
                                if(System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }
                        }
                    }
                    else
                    {
                        image.Urun = urun;
                        urun.Images.Add(image);
                    }
                }               
                urun.Marka = model.Urun.Marka;
                urun.Model = model.Urun.Model;
                urun.EklenmeTarihi = DateTime.Now;
                urun.Aciklama = model.Urun.Aciklama;
                if(urunmanager.Update(urun)>0)
                {          
                    for (int i = 0; i < model.Resim_Upload.Count; i++)
                    {
                        if(model.Resim_Upload[i]!=null)
                        { 
                           model.Resim_Upload[i].SaveAs(HttpContext.Server.MapPath("~/Images/" + model.Resim_Upload[i].FileName));
                        }
                    }
                    TempData["isEdited"] = true;
                }
                else
                {
                    TempData["isEdited"] = false;
                }
                TempData["Product"] = urun;
                return RedirectToAction("Index");
            }
            model.Urun = urunmanager.ListQueryable().Include(c => c.Images).FirstOrDefault(c => c.Id == model.Urun.Id);
            return View(model);
        }
    }
}