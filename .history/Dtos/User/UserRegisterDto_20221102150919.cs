using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Dtos.User
{
    public class RegisterUserDto
    {
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}