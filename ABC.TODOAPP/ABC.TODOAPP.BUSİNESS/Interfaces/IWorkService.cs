using ABC.TODOAPP.COMMON.CustomResponse;
using ABC.TODOAPP.DTOs.WorkDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.BUSİNESS.Interfaces
{
    public interface IWorkService
    {
        Task<IDataResponse<List<WorkListDTO>>> GetAll();
        Task<IDataResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        Task<IDataResponse<IDTO>> GetById<IDTO>(int id);
        Task<IResponse> Remove(int id);
        Task<IDataResponse<WorkUpdateDTos>> Update(WorkUpdateDTos dto);
    }
}
