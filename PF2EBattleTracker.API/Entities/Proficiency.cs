using PF2EBattleTracker.API.Enums;
using PF2EBattleTracker.API.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PF2EBattleTracker.API.Entities
{
    public class Proficiency()
    {
        [Key]
        public int ProficiencyId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public Stat Stat { get; set; }

        [Required]
        public ProficiencyLevel Level { get; set; }
        public ProficiencyType Type { get; set; }
        public bool DefaultSkill { get; set; } = true;

        public bool SaveDC { get; set; }

        [Required]
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public int CharacterId { get; set; }

        [NotMapped]
        public int TotalBonus;

        [NotMapped]
        public string Breakdown = string.Empty;

        public void CalculateBonuses(Character character)
        {
            int statscore = 0;
            StringBuilder sb = new StringBuilder();

            if(SaveDC)
            {
                TotalBonus = 10;
                sb.Append("10 + ");
            }

            switch (Stat)
            {
                case Stat.Strength:
                    statscore = character.Strength;
                    sb.Append("STR Bonus(");
                    break;
                case Stat.Dexterity:
                    statscore = character.Dexterity;
                    sb.Append("DEX Bonus(");
                    break;
                case Stat.Constitution:
                    statscore = character.Constitution;
                    sb.Append("CON Bonus(");
                    break;
                case Stat.Intelligence:
                    statscore = character.Intelligence;
                    sb.Append("INT Bonus(");
                    break;
                case Stat.Wisdom:
                    statscore = character.Wisdom;
                    sb.Append("WIS Bonus(");
                    break;
                case Stat.Charisma:
                    statscore = character.Charisma;
                    sb.Append("CHA Bonus(");
                    break;
            }

            int bonus = Helper.GetModifier(statscore);
            TotalBonus += bonus;
            sb.Append(bonus + ")");

            if (Level != ProficiencyLevel.Untrained)
            {
                TotalBonus += (int)Level + character.Level;
                sb.Append(" + Proficiency Level(" + Level.ToString() + ":" + (int)Level + ") + Level(" + character.Level + ")");
            }

            Breakdown = sb.ToString();
        }

    }
}
