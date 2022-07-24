using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_RPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;


namespace API_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService characterService;
        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
            
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetCharacters()
        {
            return Ok(await characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingleCharacter(int id)
        {   
            return Ok(await characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCharacter)
        {   
            return Ok(await characterService.AddCharacter(newCharacter));
        }
    }
}