namespace TaskApi.Models
{
    public class TaskFilter:PaginationParam
    {
        public string? Search {  get; set; }
        public bool? IsCompleted { get; set; }
        public string? Title { get; set; }

        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatesBefore { get; set; }

        public string? SortBy { get; set; }
        public string? Order { get; set; }

    }
}
