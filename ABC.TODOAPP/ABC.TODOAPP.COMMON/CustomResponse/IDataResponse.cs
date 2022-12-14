using ABC.TODOAPP.COMMON.ValidationError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.COMMON.CustomResponse
{
    public interface IDataResponse<T>:IResponse
    {
         T Data { get; set; }
         List<CustomValidationError> CustomValidationErrors { get; set; }
    }
}
