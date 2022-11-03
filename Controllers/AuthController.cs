using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rgp.Data;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rgp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//can access by string API
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        [HttpPost]
        public async Task<ServiceResponse<int>> Register(User user, string password){
            var response = await _authRepository.Register(user,password);
            if(response.Success = false){
                return response.Message.ToString();
            }
            return Ok(response);
            // return Ok(await _characterService.AddCharacter(newCharacter));
            // return Ok(await _authRepository.Register(user,password));
        }
        
    }
}