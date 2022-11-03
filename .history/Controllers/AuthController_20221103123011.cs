using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rgp.Data;
using dotnet_rgp.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rgp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//can access by string API
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            this._authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request){
            var response = await _authRepo.Register(
                new User {Username = request.Username},request.Password
            );
            if(response.Success = false){
                return BadRequest(response);
            }
            return Ok(response);
            // return Ok(await _characterService.AddCharacter(newCharacter));
            // return Ok(await _authRepository.Register(user,password));
        }
        
    }
}