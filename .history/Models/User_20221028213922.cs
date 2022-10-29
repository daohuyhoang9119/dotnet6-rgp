using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;

        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt { get; set; }        

        public List<Character>? Characters {get;set;}
    }
}