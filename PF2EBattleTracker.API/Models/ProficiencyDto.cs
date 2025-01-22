using PF2EBattleTracker.API.Enums;

namespace PF2EBattleTracker.API.Models
{
    public class ProficiencyDto
    {
        public int ProficiencyId { get; set; }

        public string Description { get; set; } = string.Empty;


        public ProficiencyType Type { get; set; }

        public int TotalBonus { get; set; }
        public string Breakdown { get; set; } = string.Empty;

    }
}
