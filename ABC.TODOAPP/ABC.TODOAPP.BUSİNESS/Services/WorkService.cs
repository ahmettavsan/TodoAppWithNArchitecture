using ABC.TODOAPP.BUSİNESS.Extensions;
using ABC.TODOAPP.BUSİNESS.Interfaces;
using ABC.TODOAPP.BUSİNESS.ValidationRules;
using ABC.TODOAPP.COMMON.CustomResponse;
using ABC.TODOAPP.COMMON.ValidationError;
using ABC.TODOAPP.DATAACCESS.Interfaces;
using ABC.TODOAPP.DTOs.WorkDTOs;
using ABC.TODOAPP.ENTITIES.Domains;
using AutoMapper;
using FluentValidation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.BUSİNESS.Services
{
    public class WorkService : IWorkService
    {
        private readonly IValidator<WorkCreateDto> _validator;
        private readonly IValidator<WorkUpdateDTos> _uValidator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<WorkCreateDto> validator, IValidator<WorkUpdateDTos> uValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _uValidator = uValidator;
        }

        public async Task<IDataResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            #region MyRegion
            //var validator = new WorkCreateDtoValidator();
            //var validationResult = validator.Validate(dto);
            //if (validationResult.IsValid)
            //{
            //    //await _unitOfWork.GetRepository<Work>().CreateAsync(new() { Definition=dto.Defination,IsComplated=dto.IsComplated});
            //    await _unitOfWork.GetRepository<Work>().CreateAsync(_mapper.Map<Work>(dto));
            //    await _unitOfWork.SaveChanges();
            //}
            #endregion
            var validateResult=  _validator.Validate(dto);
            
            if (_validator.Validate(dto).IsValid)
                
            {
                var entity = _mapper.Map<Work>(dto);
                await _unitOfWork.GetRepository<Work>().CreateAsync(entity);
                await _unitOfWork.SaveChanges();
                return new DataResponse<WorkCreateDto>(dto,ResponseType.Success);
            }
            else
            {
                return new DataResponse<WorkCreateDto>(dto, validateResult.ConvertToValidationError(), ResponseType.ValidationError);
            }
        }

        public async Task<IDataResponse<List<WorkListDTO>>> GetAll()
        {
            #region MyRegion
            //var entity= await _unitOfWork.GetRepository<Work>().GetAllAsync();
            // var entityDto = new List<WorkListDTO>();
            // if (entity!=null && entity.Count>0)
            // {
            //     foreach (var item in entity)
            //     {
            //         entityDto.Add(new()
            //         {
            //             Id=item.Id,
            //             Definition=item.Definition,
            //             IsCompleted=item.IsComplated
            //         });

            //     }
            // }
            // return entityDto;
            #endregion
            return new DataResponse<List<WorkListDTO>>(_mapper.Map<List<WorkListDTO>>(await _unitOfWork.GetRepository<Work>().GetAllAsync()),ResponseType.Success);
            //return (_mapper.Map<List<WorkListDTO>>(await _unitOfWork.GetRepository<Work>().GetAllAsync()));
        }

        public async Task<IDataResponse<IDTO>> GetById<IDTO>(int id)
        {
            #region MyRegion
            //var entity = await _unitOfWork.GetRepository<Work>().GetByIdAsync(id);
            //if (entity != null)
            //{
            //    var dto = new WorkDTO { Defination = entity.Definition, IsCompleted = entity.IsComplated, Id = entity.Id };

            //}
            //return new WorkDTO();
            //return _mapper.Map<WorkDTO>(await _unitOfWork.GetRepository<Work>().GetByIdAsync(id));
            #endregion
            var entity = await _unitOfWork.GetRepository<Work>().GetByIdAsync(id);
            if (entity!=null)
            {

                return new DataResponse<IDTO>(_mapper.Map<IDTO>(entity), ResponseType.Success);
            }
            return new DataResponse<IDTO>($"{id}Not Found", ResponseType.NotFound);
            
            //return _mapper.Map<IDTO>(await _unitOfWork.GetRepository<Work>().GetByIdAsync(id));

        }

        public async Task<IResponse> Remove(int id)
        {
            var entity = await _unitOfWork.GetRepository<Work>().GetByIdAsync(id);
            if (entity!=null)
            {
                _unitOfWork.GetRepository<Work>().Remove(entity);
                _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);

            }
            return new Response($"{id} Not Found",ResponseType.NotFound);
            //_unitOfWork.GetRepository<Work>().Remove(id);
        }

        public async Task<IDataResponse<WorkUpdateDTos>> Update(WorkUpdateDTos dto)
        {
            #region MyRegion
            //      _unitOfWork.GetRepository<Work>().Update(new Work()
            //    {
            //        Definition = dto.Defination,
            //        Id = dto.Id,
            //        IsComplated = dto.IsCompleted
            //    });

            //    await _unitOfWork.SaveChanges();
            #endregion
          var validationResult=  _uValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                var updatedentity = await _unitOfWork.GetRepository<Work>().GetByIdAsync(dto.Id);
                if (updatedentity!=null)
                {
                    _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updatedentity);
                    await _unitOfWork.SaveChanges();

                    return new DataResponse<WorkUpdateDTos>(dto,ResponseType.Success);

                }
                return new DataResponse<WorkUpdateDTos>($"{dto.Id} Not Found", ResponseType.NotFound);
            }
            else
            {
               
                return new DataResponse<WorkUpdateDTos>(dto, validationResult.ConvertToValidationError(), ResponseType.ValidationError);
            }






        }
    }
}
