namespace TaskApi.Models
{
    public class PaginationParam
    {
        private const int MaxPageSize=100;
        private int _pageSize=100;
        public int Page { get; set; } = 1;
        public int PageSize {
            get { return _pageSize; }

            set { _pageSize=value > MaxPageSize ? MaxPageSize:value ; }
        }
    }
}
