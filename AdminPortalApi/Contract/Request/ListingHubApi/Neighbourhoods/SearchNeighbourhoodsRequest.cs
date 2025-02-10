namespace Contract.Request.Neighbourhoods
{
    public class SearchNeighbourhoodsRequest : PaginatedRequest
    {
        public int? districtId { get; set; }
        public string? name { get; set; }
    }
}
