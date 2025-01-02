using PF2EBattleTracker.API.Entities;
using System.Threading.Tasks;

namespace PF2EBattleTracker.API.Services
{
    public interface ICharacterInfoRepository
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Character>> GetCharactersAsync();

        Task<(IEnumerable<Character>, PaginationMetaData)> GetCharactersAsync(string? name, string? searchQuery, int pageNumber, int pageSize);

        Task<Character?> GetCharacterAsync(int characterId, bool includeDetails);

        Task<bool> CharacterExistsAsync(int characterId);

        Task<IEnumerable<Condition>> GetConditionsForCharacterAsync(int characterId);

        Task<Condition?> GetConditionForCharacterAsync(int characterId, int conditionId);

        Task AddConditionToCharacterAsync(int characterId,  Condition condition);

        void DeleteCondition(Condition condition);
    }
}
 