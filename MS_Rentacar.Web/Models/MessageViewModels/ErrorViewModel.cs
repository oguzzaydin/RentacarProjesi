using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_Rentacar.Web.Models.MessageViewModels
{
    public class ErrorViewModel<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public string Process{get;set;}
    }
}