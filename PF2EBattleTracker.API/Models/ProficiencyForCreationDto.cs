using PF2EBattleTracker.API.Enums;

namespace PF2EBattleTracker.API.Models
{
    public class ProficiencyForCreationDto
    {
        public string Description { get; set; } = string.Empty;

        public Stat Stat { get; set; }

        public ProficiencyType Type { get; set; }

        public ProficiencyLevel Level { get; set; } = 0;

        public bool SaveDC { get; set; }
    }
}
