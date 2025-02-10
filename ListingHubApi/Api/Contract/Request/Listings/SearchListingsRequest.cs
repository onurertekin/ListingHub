namespace Contract.Request.Listings
{
    public class SearchListingsRequest : PaginatedRequest
    {
        public int? categoryId { get; set; }
        public string? title { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public int? cityId { get; set; }
        public int? districtId { get; set; }
        public int? neighbourhoodId { get; set; }
        public int? subNeighbourhoodId { get; set; }
        public int? userId { get; set; }
        public DateTime? listingDate { get; set; }
        public string? latLong { get; set; }
        public string? photo { get; set; }
    }
}
