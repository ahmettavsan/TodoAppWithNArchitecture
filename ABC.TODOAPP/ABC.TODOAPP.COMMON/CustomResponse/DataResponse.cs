using ABC.TODOAPP.COMMON.ValidationError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.COMMON.CustomResponse
{
    public class DataResponse<T>:Response ,IDataResponse<T>
    {
        
        //ResponseType----->success,validationerror,notfound
        public T Data { get; set; }
        public List<CustomValidationError> CustomValidationErrors { get; set; }
        public DataResponse(T data,ResponseType responseType):base(responseType)
        {
            Data = data; //success
        }
        public DataResponse(T data, List<CustomValidationError> customValidationErrors,ResponseType responseType):base(responseType)
        {
            //validation error
            Data = data;
            CustomValidationErrors = customValidationErrors;
        }
        public DataResponse(string message,ResponseType responseType) : base(message, responseType)
        {

        }
    }
}
