using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rgp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//can access by string API
    public class CharactorController : ControllerBase
    {
        //we want a list character
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Name = "Ronaldo", HitPoints = 500},
            new Character{ Name = "Anthony", HitPoints = 200},
            new Character{ Name = "Rashford", HitPoints = 200},
            new Character{ Name = "Bruno", Intelligence = 200},
            
        };
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }
        [HttpGet]
        public ActionResult<Character> GetSingle(){
            return Ok(characters[0]);
        }
        
    }
}