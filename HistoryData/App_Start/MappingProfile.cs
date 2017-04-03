using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HistoryData.Models;
using HistoryData.Dtos;

namespace HistoryData.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<History, HistoryDto>();
            Mapper.CreateMap<HistoryDto, History>();
        }
    }
}