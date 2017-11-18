using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class GelenMesajlar
    {
        [Key]
        public string Id { get; set; }
        [Required,DataType(DataType.EmailAddress,ErrorMessage ="Geçerli bir E-Mail adresi giriniz.")]
        public string GonderenMail{get;set;}
        [Required]
        public string AdSoyad{ get; set; }
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Mesaj { get; set; }

    }
}
