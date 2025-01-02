using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PF2EBattleTracker.API.DbContexts;
using PF2EBattleTracker.API.Entities;
using System.Collections.Generic;

namespace PF2EBattleTracker.API.Services
{
    public class CharacterInfoRepository : ICharacterInfoRepository
    {
        private readonly CharacterInfoContext _context;

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >=0);
        }

        public CharacterInfoRepository(CharacterInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }        

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await _context.Characters.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<(IEnumerable<Character>, PaginationMetaData)> GetCharactersAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Characters as IQueryable<Character>;

            if (!string.IsNullOrEmpty(name))
            {
                name = name.Trim();
                collection = collection.Where( x  => x.Name == name );
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery.Trim();
                collection = collection.Where(x => x.Name.Contains(searchQuery));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);
            
            var collectionToReturn = await collection
                .OrderBy(x => x.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<Character?> GetCharacterAsync(int characterId, bool includeDetails)
        {
            if (includeDetails)
            {
                return await _context.Characters.Include(x => x.Conditions).Where(x => x.CharacterId == characterId).FirstOrDefaultAsync();
            }

            return await _context.Characters.Where(x => x.CharacterId == characterId).FirstOrDefaultAsync();
        }

        public async Task<bool> CharacterExistsAsync(int characterId)
        {
            return await _context.Characters.AnyAsync(x => x.CharacterId == characterId);
        }

        public async Task<IEnumerable<Condition>> GetConditionsForCharacterAsync(int characterId)
        {
            return await _context.Conditions.Where(x => x.CharacterId == characterId).ToListAsync();
        }

        public async Task<Condition?> GetConditionForCharacterAsync(int characterId, int conditionId)
        {
            return await _context.Conditions.Where(x => x.CharacterId == characterId && x.ConditionId == conditionId).FirstOrDefaultAsync();
        }

        public async Task AddConditionToCharacterAsync(int characterId, Condition condition)
        {
            var character = await GetCharacterAsync(characterId, false);
            if (character != null)
            {
                character.Conditions.Add(condition);
            }
        }

        public void DeleteCondition(Condition condition)
        {
            _context.Conditions.Remove(condition);
        }
    }
}
