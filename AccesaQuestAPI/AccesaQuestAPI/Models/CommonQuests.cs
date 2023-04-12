using System.ComponentModel.DataAnnotations;

namespace AccesaQuestAPI.Models
{
    public class CommonQuests
    {
        [Key]
        public int Id { get; set; }
        public string QuestName { get; set; }
        public string QuestBody { get; set; }
        public int QuestXp { get; set; }
        public int QuestPoints { get; set; }
    }
}
