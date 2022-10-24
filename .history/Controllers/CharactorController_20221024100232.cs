using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rgp.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rgp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//can access by string API
    public class CharactorController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        //we want a list character
        public CharactorController(ICharacterService characterService){
            this._characterService = characterService;
        }
        //get all character
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get(){
            return  Ok(await _characterService.GetAllCharacters());
        }

        //get character by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        //add new character
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCharacter){
            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        
    }
}