
namespace TaskApi.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status = string.Empty;
    }
}
