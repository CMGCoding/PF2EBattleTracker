namespace PF2EBattleTracker.API.Services
{
    public static class Helper
    {        
        public static int GetModifier(int score)
        {
            return Convert.ToInt32(Math.Floor((Decimal)score / 2)) - 5;
        }
    }
}
