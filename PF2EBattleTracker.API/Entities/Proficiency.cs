using PF2EBattleTracker.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PF2EBattleTracker.API.Entities
{
    public class Proficiency(string description, string stat, ProficiencyLevel level, ProficiencyType type)
    {
        [Key]
        public int ProficiencyId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Description { get; set; } = description;

        [Required]
        public string Stat { get; set; } = stat;

        [Required]
        public ProficiencyLevel Level { get; set; } = level;
        public ProficiencyType Type { get; set; } = type;
        public bool LoreSkill { get; set; } = false;

        [Required]
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public int CharacterId { get; set; }

        public Proficiency(Character character, string description, string stat, ProficiencyLevel level, ProficiencyType type, bool loreSkill) : this(description, stat, level, type)
        {
            LoreSkill = loreSkill;
        }
        
    }
}
