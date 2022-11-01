using ABC.TODOAPP.DTOs.WorkDTOs;
using ABC.TODOAPP.ENTITIES.Domains;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.BUSİNESS.Mapping.AutoMapper
{
    public class WorkProfile:Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkDTO>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDTos>().ReverseMap();
            CreateMap<Work,WorkListDTO>().ReverseMap();


        }
    }
}
