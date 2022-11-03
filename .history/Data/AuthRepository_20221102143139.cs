using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            ServiceResponse<int> response = new ServiceResponse<int>();
            response.Data = user.UserId;
            return response;            
        }

        public Task<ServiceResponse<string>> UserExits(string username)
        {
            throw new NotImplementedException();
        }
        private CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt){
            using ( var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}