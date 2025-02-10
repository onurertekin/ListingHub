namespace Contract.Request.SubNeighbourhoods
{
    public class SearchSubNeighbourhoodsRequest : PaginatedRequest
    {
        public int? neighbourhoodId { get; set; }
        public string? name { get; set; }
    }
}
