using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
          private static List<Character> characters = new List<Character> 
        {
            new Character(){Id = 1, Name = "Simbus"},
           
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();

           characters.Add(newCharacter);
           serviceResponse.Data = characters;
           return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacter()
        {
            return new ServiceResponse<List<Character>>{Data = characters};
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = character;

            if(character == null)
            {
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }
            
            return serviceResponse;
        }
    }
}