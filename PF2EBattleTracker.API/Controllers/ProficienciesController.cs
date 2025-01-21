using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PF2EBattleTracker.API.Entities;
using PF2EBattleTracker.API.Models;
using PF2EBattleTracker.API.Services;

namespace PF2EBattleTracker.API.Controllers
{
    [Route("api/characters/{characterId}/proficiencies")]
    [ApiController]
    public class ProficienciesController : ControllerBase
    {
        private readonly ICharacterInfoRepository _characterInfoRepository;
        private readonly IMapper _mapper;

        public ProficienciesController(
            ICharacterInfoRepository characterInfoRepository,
            IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _characterInfoRepository = characterInfoRepository ?? throw new ArgumentNullException(nameof(characterInfoRepository));
        }

        public async Task<ActionResult<IEnumerable<ProficiencyDto>>> GetProficiencies(int characterId)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            var proficienciesForCharacter = await _characterInfoRepository.GetProficienciesForCharacterAsync(characterId);

            return Ok(_mapper.Map<IEnumerable<ProficiencyDto>>(proficienciesForCharacter));
        }

        [HttpGet("{ProficiencyId}", Name = "GetProficiency")]
        public async Task<ActionResult<ProficiencyDto>> GetProficiency(int characterId, int proficiencyId)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }
            var proficiencyForCharacter = await _characterInfoRepository.GetProficiencyForCharacterAsync(characterId, proficiencyId);
            if (proficiencyForCharacter == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProficiencyDto>(proficiencyForCharacter));
        }

        [HttpPost]
        public async Task<ActionResult<ProficiencyDto>> CreateProficiency(int characterId, ProficiencyForCreationDto proficiency)
        {
            Character? c = await _characterInfoRepository.GetCharacterAsync(characterId, false) ?? null;

            if (c == null)
            {
                return NotFound();
            }

            var newProficiency = _mapper.Map<Proficiency>(proficiency);
            newProficiency.DefaultSkill = false;

            await _characterInfoRepository.AddProficiencyToCharacterAsync(characterId, newProficiency);
            await _characterInfoRepository.SaveChangesAsync();

            newProficiency.CalculateBonuses(c);

            return CreatedAtRoute("GetProficiency",
                new { characterId, proficiencyId = newProficiency.ProficiencyId },
                _mapper.Map<ProficiencyDto>(newProficiency));
        }

        [HttpPatch("{proficiencyId}")]
        public async Task<ActionResult<ProficiencyDto>> UpdateProficiency(int characterId, int proficiencyId, JsonPatchDocument<ProficiencyForUpdateDto> patchDoc)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            var proficiencyEntity = await _characterInfoRepository.GetProficiencyForCharacterAsync(characterId, proficiencyId);

            if (proficiencyEntity == null)
            {
                return NotFound();
            }

            var proficiencyToPatch = _mapper.Map<ProficiencyForUpdateDto>(proficiencyEntity);

            patchDoc.ApplyTo(proficiencyToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(proficiencyToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(proficiencyToPatch, proficiencyEntity);

            await _characterInfoRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{proficiencyId}")]
        public async Task<ActionResult> DeleteProficiency(int characterId, int proficiencyId)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }
            var proficiencyEntity = await _characterInfoRepository.GetProficiencyForCharacterAsync(characterId, proficiencyId);
            if (proficiencyEntity == null)
            {
                return NotFound();
            }
            _characterInfoRepository.DeleteProficiency(proficiencyEntity);
            await _characterInfoRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
