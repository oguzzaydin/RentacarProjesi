using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.EntityFramework
{
    public class MsUser
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        [Required,DataType(DataType.EmailAddress,ErrorMessage ="E-mail geçersiz.")]
        public string Email { get; set; }

    }
}
