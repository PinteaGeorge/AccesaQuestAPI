using System.ComponentModel.DataAnnotations;

namespace AccesaQuestAPI.Models
{
    public class CompletedQuestsFromUser
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QuestName { get; set; }
        public string QuestBody { get; set; }
        public int CompletedUserId { get; set; }
        public bool QuestCompleted { get; set; }
    }
}
