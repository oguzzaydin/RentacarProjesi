using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.Entities.Messages
{
    public class ErrorMessageObject
    {
        public ErrorMessageCodes Code { get; set; }
        public string Message { get; set; }
    }
}
