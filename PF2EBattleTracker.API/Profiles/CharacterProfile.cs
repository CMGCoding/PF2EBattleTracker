using AutoMapper;

namespace PF2EBattleTracker.API.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Entities.Character, Models.CharacterForListDto>();
            CreateMap<Entities.Character, Models.CharacterDto>();
        }
    }
}
