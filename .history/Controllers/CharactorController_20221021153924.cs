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
            new Character{Id = 1, Name = "Ronaldo", HitPoints = 500},
            new Character{Id = 2, Name = "Anthony", HitPoints = 200},
            new Character{ Id = 3,Name = "Rashford", HitPoints = 200},
            new Character{ Id = 4,Name = "Bruno", Intelligence = 200},
            
        };
        [HttpGet("GetAll")]
        
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
        
    }
}