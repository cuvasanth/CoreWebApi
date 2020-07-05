using AutoMapper;
using NewWebApi.Dtos;
using NewWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApi.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
