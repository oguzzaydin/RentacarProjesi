using MS_Rentacar.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_Rentacar.Web.Models
{
    public class UrunlerViewModel
    {
        public Urunler Urun { get; set; }
        public List<HttpPostedFileBase> Resim_Upload { get; set; }
        public List<bool> _ischeck { get; set; }
        public List<string> _checkvalue { get; set; }

        public UrunlerViewModel()
        {
            _ischeck = new List<bool>();
            _checkvalue = new List<string>();
            Resim_Upload = new List<HttpPostedFileBase>();
        }
    }
}