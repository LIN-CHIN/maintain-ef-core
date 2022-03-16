using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maintainProject.Models
{
    public class HttpResultModel
    {
        public string _status_code { get; set; }
        public string _message { get; set; }

        public HttpResultModel(string status_code, string message) 
        {
            _status_code = status_code;
            _message = message;
        }
      
    }
}
