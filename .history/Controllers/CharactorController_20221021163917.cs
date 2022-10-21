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
        [HttpGet("GetAll")]
        
        public ActionResult<List<Character>> Get(){
            return Ok(_characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(_characterService.GetCharacterById(id));
        }


        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            
            return Ok(_characterService.AddCharacter(newCharacter));
        }
        
    }
}