using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rgp.Data;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rgp.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _authRepository;
        public AuthController(AuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }
    }
}