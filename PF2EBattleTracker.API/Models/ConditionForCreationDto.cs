using System.ComponentModel.DataAnnotations;

namespace PF2EBattleTracker.API.Models
{
    public class ConditionForCreationDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Source { get; set; } = string.Empty;
        
        public int? Value { get; set; }
    } 
}
