using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_RPG.Dtos.CharacterDtos;
using AutoMapper;

namespace API_RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
        
    }
}