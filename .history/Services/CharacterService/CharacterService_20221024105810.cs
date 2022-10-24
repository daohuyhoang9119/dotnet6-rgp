using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rgp.Dtos.Character;

namespace dotnet_rgp.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        public CharacterService(IMapper mapper)
        {
            this.mapper = mapper;
        }
         private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Ronaldo", HitPoints = 500},
            new Character{Id = 2, Name = "Anthony", HitPoints = 200},
            new Character{ Id = 3,Name = "Rashford", HitPoints = 200},
            new Character{ Id = 4,Name = "Bruno", Intelligence = 200},
            
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id); 
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}