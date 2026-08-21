namespace TaskApi.Dtos
{
    public class CreateTaskRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
    }
}
