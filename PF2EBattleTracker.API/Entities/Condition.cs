using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PF2EBattleTracker.API.Entities
{
    public class Condition(string name)
    {
        [Key]
        public int ConditionId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = name;

        [Required]
        [MaxLength(30)]
        public string Source { get; set; } = string.Empty;
        public int? Value { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public int CharacterId { get; set; }
    }
}
