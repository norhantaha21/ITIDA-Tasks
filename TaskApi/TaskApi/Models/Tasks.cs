
namespace TaskApi.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status = string.Empty;

        //Foreign key
        public int UserId { get; set; }

        //Navigation property
        public Users? User { get; set; }
    }
}
