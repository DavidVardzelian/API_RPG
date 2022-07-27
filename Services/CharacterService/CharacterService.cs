using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_RPG.Dtos.CharacterDtos;
using AutoMapper;

namespace API_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
          private static List<Character> characters = new List<Character> 
        {
            new Character(){Id = 1, Name = "Shlang"},
           
        };
        private readonly IMapper mapper;

        public CharacterService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
           Character character = mapper.Map<Character>(newCharacter);
           character.Id = characters.Max(c => c.Id)+ 1;
           characters.Add(character);


           serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
           return serviceResponse; 
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
           ServiceResponse<List<GetCharacterDto>>response = new ServiceResponse<List<GetCharacterDto>>();
           try
           {
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                response.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
           }
           catch (Exception ex)
           {
            response.Success = false; 
            response.Message = ex.Message;
           
           }
           return response;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            return new ServiceResponse<List<GetCharacterDto>>
            {
                Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = mapper.Map<GetCharacterDto>(character);  
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto UpdatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == UpdatedCharacter.Id);
                mapper.Map(UpdatedCharacter, character);
                response.Data = mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
               
            }
            
            return response;
        }

    }
}