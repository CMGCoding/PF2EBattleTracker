using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PF2EBattleTracker.API.Models;
using PF2EBattleTracker.API.Services;
using System.Text.Json;

namespace PF2EBattleTracker.API.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterInfoRepository _characterInfoRepository;
        private readonly IMapper _mapper;
        const int maxCharactersPageSize = 10;

        public CharactersController(ICharacterInfoRepository characterInfoRepository, IMapper mapper)
        {
            _characterInfoRepository = characterInfoRepository ?? throw new ArgumentNullException(nameof(characterInfoRepository));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterForListDto>>> GetCharacters(
            [FromQuery()] string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {

            if (pageSize > maxCharactersPageSize)
            {
                pageSize = maxCharactersPageSize;
            }

            var (characterEntities, paginationMetaData) = await _characterInfoRepository.GetCharactersAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<CharacterForListDto>>(characterEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacter(int id, bool includeDetails = false)
        {
            var character = await _characterInfoRepository.GetCharacterAsync(id, includeDetails);

            if (character == null)
            {
                return NotFound();
            }

            if (includeDetails)
            {
                return Ok(_mapper.Map<CharacterDto>(character));
            }

            return Ok(_mapper.Map<CharacterForListDto>(character));

        }
    }
}
