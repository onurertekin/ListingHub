namespace Contract.Request.Cities
{
    public class SearchCitiesRequest : PaginatedRequest
    {
        public string? name { get; set; }
        public int? plateCode { get; set; }
    }
}
