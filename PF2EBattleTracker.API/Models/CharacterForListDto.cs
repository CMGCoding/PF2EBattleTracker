using PF2EBattleTracker.API.Services;
using System.ComponentModel.DataAnnotations;

namespace PF2EBattleTracker.API.Models
{
    public class CharacterForListDto
    {
        public int CharacterId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Level { get; set; }
    }
}
