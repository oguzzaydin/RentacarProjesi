using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class Urunler
    {
        [Key]
        public string Id { get; set; }
        public string Aciklama { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        public virtual List<Images> Images { get; set; }

        public Urunler()
        {
            Images = new List<EntityFramework.Images>();
        }
    }
}
