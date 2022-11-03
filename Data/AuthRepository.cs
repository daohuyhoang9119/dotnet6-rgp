using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rgp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;
        }

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalt);
            if(await UserExits(user.Username)){
                response.Success = false;
                response.Message = "User already exits";
                return response;
            }
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.UserId;
            return response;          
        }

        public async Task<bool> UserExits(string username)
        {
            var serviceResponse = new ServiceResponse<string>();
            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return false;
            }
            return true;
        }
        private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt){
            using ( var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
    }
}
    