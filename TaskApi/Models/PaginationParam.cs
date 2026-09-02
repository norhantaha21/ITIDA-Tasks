namespace TaskApi.Models
{
    public class PaginationParam
    {
        public int MaxPageSize { get; set; } = 100;
        public int Page { get; set; } = 1;
        private  int _pageSize=10;

        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : (value <= 0 ? 10 : value); }
        }
    }
}
