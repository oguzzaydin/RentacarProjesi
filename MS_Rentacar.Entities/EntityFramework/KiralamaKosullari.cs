using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class KiralamaKosullari
    {
        [Key]
        public string Id { get; set; }
        public string Aciklama { get; set; }



    }
}
