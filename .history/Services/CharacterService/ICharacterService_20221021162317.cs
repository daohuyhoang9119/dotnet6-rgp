using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgp.Services.CharacterService
{
    public class ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        
        List<Character> AddCharacter(Character newCharecter);
    }
}