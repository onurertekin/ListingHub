namespace Contract.Request.Districts
{
    public class SearchDistrictsRequest : PaginatedRequest
    {
        public string? name { get; set; }
        public int? cityId { get; set; }
    }
}
