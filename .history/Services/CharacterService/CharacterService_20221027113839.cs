using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rgp.Data;
using dotnet_rgp.Dtos.Character;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rgp.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;
        }
         private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Ronaldo", HitPoints = 500},
            new Character{Id = 2, Name = "Anthony", HitPoints = 200},
            new Character{ Id = 3,Name = "Rashford", HitPoints = 200},
            new Character{ Id = 4,Name = "Bruno", Intelligence = 200},
            
        };

        //ADD
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            // characters.Add(newCharacter);
            // characters.Add(_mapper.Map<Character>(newCharacter));
            //tìm thằng lớn nhất nếu có sau đó tăng index lên 1
            //tạo thằng cần thêm
            Character character = _mapper.Map<Character>(newCharacter);
            //tìm id của th lớn r cộng vào cho th mới
            // character.Id = characters.Max(c => c.Id) + 1;
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            // serviceResponse.Data = characters;
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }
        // GET
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c =>  _mapper.Map<GetCharacterDto>(c)).ToList();
            return  serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id); 
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }
        // UPDATE
        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try{
                var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                // Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);  
                // _mapper.Map<Character>(updatedCharacter);
                dbCharacter.Name = updatedCharacter.Name;
                dbCharacter.HitPoints = updatedCharacter.HitPoints;
                dbCharacter.Strength = updatedCharacter.Strength;
                dbCharacter.Defense = updatedCharacter.Defense;
                dbCharacter.Intelligence = updatedCharacter.Intelligence;
                dbCharacter.Class = updatedCharacter.Class;
                response.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // DELETE
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        { 
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try{
                Character deletedCharacter = characters.First(c => c.Id == id);  
                characters.Remove(deletedCharacter);
            
                response.Data = characters.Select(c =>  _mapper.Map<GetCharacterDto>(c)).ToList();
            }catch (Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}