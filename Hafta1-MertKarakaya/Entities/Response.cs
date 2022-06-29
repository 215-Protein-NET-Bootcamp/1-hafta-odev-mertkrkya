using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta1_MertKarakaya.Entities
{
    public class Response
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
        public Response(object data)
        {
            success = true;
            errorMessage = null;
            this.data = data;
        }
        public Response(string errorMessage)
        {
            success = false;
            this.errorMessage = errorMessage;
            data = null;
        }
    }
}
