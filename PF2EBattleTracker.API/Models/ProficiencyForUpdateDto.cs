using PF2EBattleTracker.API.Enums;

namespace PF2EBattleTracker.API.Models
{
    public class ProficiencyForUpdateDto
    {
        public string Description { get; set; } = string.Empty;

        public ProficiencyLevel Level { get; set; }
    }
}
