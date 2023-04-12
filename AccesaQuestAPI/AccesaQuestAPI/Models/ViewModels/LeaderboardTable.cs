namespace AccesaQuestAPI.Models.ViewModels
{
    public class LeaderboardTable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int QuestsCompleted { get; set; }
        public int QuestsComposed { get; set; }

    }
}
