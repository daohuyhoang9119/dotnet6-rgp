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
        private static Character knight = new Character();
        public IActionResult Get(){
            return Ok(knight);
        }
        
    }
}