using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Data
{
    public class IAuthRepository 
    {
        Task<ServiceResponse<int>> Register(User user,string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<string>> UserExits(string username);
    }
}