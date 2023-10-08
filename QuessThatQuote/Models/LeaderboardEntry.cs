namespace QuessThatQuote.Models
{
    public class LeaderboardEntry
    {
        public Guid Id { get; set; }
        public string GameType { get; set; }
        public string DisplayName { get; set; }
        public int Score { get; set; }
    }
}
