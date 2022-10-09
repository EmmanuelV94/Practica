using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Response
    {
        public Response()
        {
            Success = true;
            Message = String.Empty;
        }
        public bool Success { get; set; }
        public string Message { get; set; }

        public void Reset()
        {
            Success = true;
            Message = string.Empty;
        }
    }
}
