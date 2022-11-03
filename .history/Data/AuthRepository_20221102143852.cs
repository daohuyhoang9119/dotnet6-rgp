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

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
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
        private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt){
            using ( var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
    }
    