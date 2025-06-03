namespace GreenMarket.Application.Common.Pagination
{
    public class PaginatedQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; } = "Id desc";
    }
}
