namespace TaskApi.Models
{
    public class PaginationParam
    {
        public int MaxPageSize { get; set; } = 100;
        public int Page { get; set; } = 1;
        private readonly int _pageSize;

        public int PageSize {
            get { return _pageSize; }
            set { PageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
    }
}
