using PF2EBattleTracker.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PF2EBattleTracker.API.Entities
{
    public class Character(string name, int level)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = name;

        public int Level { get; set; } = level;

        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }

        public ICollection<Condition> Conditions { get; set; } = new List<Condition>();
    }
}
