namespace AccesaQuestAPI.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int Points { get; set; }
        public int QuestsCompleted { get; set; }
        public int QuestsComposed { get; set; }
    }
}
