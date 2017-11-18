using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class Slider
    {
        [Key]
        public string Id { get; set; }
        public string ImageUrl { get; set;}
        public string Baslik { get; set; }
        public string Metin { get; set; }

    }
}
