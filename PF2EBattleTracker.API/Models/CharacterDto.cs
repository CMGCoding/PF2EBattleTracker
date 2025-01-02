using PF2EBattleTracker.API.Services;
using System.ComponentModel.DataAnnotations;

namespace PF2EBattleTracker.API.Models
{
    public class CharacterDto
    {
        public int CharacterId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Level { get; set; }

        [Required]
        public int Strength { get; set; }

        public int StrenthMod
        {
            get
            {
                return Helper.GetModifier(Strength);
            }
        }

        [Required]
        public int Dexterity { get; set; }

        public int DexterityMod
        {
            get
            {
                return Helper.GetModifier(Dexterity);
            }
        }

        [Required]
        public int Constitution { get; set; }
        public int ConstitutionMod
        {
            get
            {
                return Helper.GetModifier(Constitution);
            }
        }

        [Required]
        public int Intelligence { get; set; }
        public int IntelligenceMod
        {
            get
            {
                return Helper.GetModifier(Intelligence);
            }
        }

        [Required]
        public int Wisdom { get; set; }
        public int WisdomMod
        {
            get
            {
                return Helper.GetModifier(Wisdom);
            }
        }
        [Required]
        public int Charisma { get; set; }
        public int CharismaMod
        {
            get
            {
                return Helper.GetModifier(Charisma);
            }
        }

        public int NumberOfConditions
        {
            get
            {
                return Conditions.Count;
            }
        }

        

        public ICollection<ConditionDto> Conditions { get; set; } = new List<ConditionDto>();
    }
}
