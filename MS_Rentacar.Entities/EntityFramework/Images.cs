using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class Images
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        

        public virtual Urunler Urun { get; set; }
    }
}
