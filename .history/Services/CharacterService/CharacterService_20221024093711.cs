using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
         private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Ronaldo", HitPoints = 500},
            new Character{Id = 2, Name = "Anthony", HitPoints = 200},
            new Character{ Id = 3,Name = "Rashford", HitPoints = 200},
            new Character{ Id = 4,Name = "Bruno", Intelligence = 200},
            
        };
        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}