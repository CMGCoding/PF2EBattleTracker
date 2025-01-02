namespace PF2EBattleTracker.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@pf2e.com";
        private string _mailFrom = "noreply@pf2e.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
