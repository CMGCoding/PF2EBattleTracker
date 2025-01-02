namespace PF2EBattleTracker.API.Models
{
    public class ConditionDto
    {
        public int ConditionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Source {  get; set; } = string.Empty;
        public int? Value { get; set; }
    }
}
