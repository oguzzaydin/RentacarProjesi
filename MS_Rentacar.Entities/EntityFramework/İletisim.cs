using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class İletisim
    {
        [Key]
        public string Id { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir telefon numarası adresi giriniz.")]
        public string Telefon1 { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir telefon numarası adresi giriniz.")]
        public string Telefon2 { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Geçerli bir E-Mail adresi giriniz.")]
        public string Email1 { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir E-Mail adresi giriniz.")]
        public string Email2 { get; set; }

        public string Adres { get; set; }

    }
}
