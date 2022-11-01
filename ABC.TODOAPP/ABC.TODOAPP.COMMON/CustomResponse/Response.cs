using ABC.TODOAPP.COMMON.ValidationError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.COMMON.CustomResponse
{
    public class Response:IResponse
    {

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

        public Response(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;    
        }
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
    }

    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
}
