using AutoMapper;
using PF2EBattleTracker.API.Entities;

namespace PF2EBattleTracker.API.Profiles
{
    public class ProficiencyProfile : Profile
    {
        public ProficiencyProfile()
        {
            CreateMap<Entities.Proficiency, Models.ProficiencyDto>();
            CreateMap<Models.ProficiencyForCreationDto, Entities.Proficiency>();
            CreateMap<Models.ProficiencyForUpdateDto, Entities.Proficiency>();
            CreateMap<Entities.Proficiency, Models.ProficiencyForUpdateDto>();
        }
    }
}
