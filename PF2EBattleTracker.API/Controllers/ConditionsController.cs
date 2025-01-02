using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PF2EBattleTracker.API.Entities;
using PF2EBattleTracker.API.Models;
using PF2EBattleTracker.API.Services;

namespace PF2EBattleTracker.API.Controllers
{
    [Route("api/characters/{characterId}/conditions")]
    [ApiController]
    public class ConditionsController : ControllerBase        
    {
        private readonly ILogger<ConditionsController> _logger;
        private readonly IMailService _mailService;
        private readonly ICharacterInfoRepository _characterInfoRepository;
        private readonly IMapper _mapper;

        public ConditionsController(
            ILogger<ConditionsController> logger, 
            IMailService mailService, 
            ICharacterInfoRepository characterInfoRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _characterInfoRepository = characterInfoRepository ?? throw new ArgumentNullException(nameof(characterInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionDto>>> GetConditions(int characterId)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            var conditionsForCharacter = await _characterInfoRepository.GetConditionsForCharacterAsync(characterId);

            return Ok(_mapper.Map<IEnumerable<ConditionDto>>(conditionsForCharacter));
        }

        [HttpGet("{conditionId}", Name = "GetCondition")]
        public async Task<ActionResult<ConditionDto>> GetCondition(int characterId, int conditionId)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            var conditionToReturn = await _characterInfoRepository.GetConditionForCharacterAsync(characterId, conditionId);

            if (conditionToReturn == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ConditionDto>(conditionToReturn));
        }

        [HttpPost]
        public async Task<ActionResult<ConditionDto>> CreateCondition(int characterId, ConditionForCreationDto condition)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            //Max condition value is 4
            if (condition.Value > 4)
            {
                condition.Value = 4;
            }

            var newCondition = _mapper.Map<Entities.Condition>(condition);

            await _characterInfoRepository.AddConditionToCharacterAsync(characterId, newCondition);

            await _characterInfoRepository.SaveChangesAsync();

            var createdConditionToReturn = _mapper.Map<ConditionDto>(newCondition);

            return CreatedAtRoute("GetCondition",
                new
                {
                    characterId = characterId,
                    conditionId = createdConditionToReturn.ConditionId
                },
                createdConditionToReturn
             );
            
        }

        [HttpPut("{conditionId}")]
        public async Task<ActionResult> UpdateCondition(int characterId, int conditionId, ConditionForUpdateDto condition)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            if (condition.Value > 4)
            {
                condition.Value = 4;
            }

            var conditionEntity = await _characterInfoRepository.GetConditionForCharacterAsync(characterId, conditionId);

            if (conditionEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(condition, conditionEntity);

            await _characterInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{conditionId}")]
        public async Task<ActionResult> PartiallyUpdateCondition(int characterId, int conditionId, JsonPatchDocument<ConditionForUpdateDto> patchDoc)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            var conditionEntity = await _characterInfoRepository.GetConditionForCharacterAsync(characterId, conditionId);

            if (conditionEntity == null)
            {
                return NotFound();
            }

            var conditionToPatch = _mapper.Map<ConditionForUpdateDto>(conditionEntity);

            if (conditionToPatch.Value > 4)
            {
                conditionToPatch.Value = 4;
            }

            patchDoc.ApplyTo(conditionToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(conditionToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(conditionToPatch, conditionEntity);

            await _characterInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{conditionId}")]
        public async Task<ActionResult> DeleteCondition(int characterId, int conditionId)
        {
            if (!await _characterInfoRepository.CharacterExistsAsync(characterId))
            {
                return NotFound();
            }

            var conditionEntity = await _characterInfoRepository.GetConditionForCharacterAsync(characterId, conditionId);

            if (conditionEntity == null)
            {
                return NotFound();
            }

            _characterInfoRepository.DeleteCondition(conditionEntity);

            await _characterInfoRepository.SaveChangesAsync();

            _mailService.Send("Condition Deleted.", $"Condtion {conditionEntity.Name} with id {conditionEntity.ConditionId} was deleted.");

            return NoContent();
        }
    }
}
