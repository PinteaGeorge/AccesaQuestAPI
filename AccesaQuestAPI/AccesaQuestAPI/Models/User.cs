using System.ComponentModel.DataAnnotations;

namespace AccesaQuestAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int Points { get; set; }
        public int QuestsCompleted { get; set; }
        public int QuestsComposed { get; set; }
    }
}
