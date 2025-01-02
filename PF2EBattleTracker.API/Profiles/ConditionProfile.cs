using AutoMapper;
using PF2EBattleTracker.API.Entities;

namespace PF2EBattleTracker.API.Profiles
{
    public class ConditionProfile : Profile
    {
        public ConditionProfile()
        {
            CreateMap<Entities.Condition, Models.ConditionDto>();
            CreateMap<Models.ConditionForCreationDto, Entities.Condition>();
            CreateMap<Models.ConditionForUpdateDto, Entities.Condition>();
            CreateMap<Entities.Condition, Models.ConditionForUpdateDto>();
        }
    }
}
