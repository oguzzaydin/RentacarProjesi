using MS_Rentacar.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.BusinessLayer.Results
{
    public class BusinessLayerResult<T> where T : class
    {
        public T Result { get; set; }
        public List<ErrorMessageObject> Errors{get;set;}
        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObject>();
        }
        public void AddError(ErrorMessageCodes code,string message)
        {
            Errors.Add(new ErrorMessageObject { Code = code, Message = message });
        }
}
}
