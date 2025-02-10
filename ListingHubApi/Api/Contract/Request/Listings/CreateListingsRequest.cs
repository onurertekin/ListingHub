namespace Contract.Request.Listings
{
    public class CreateListingsRequest
    {
        public int categoryId { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public int cityId { get; set; }
        public int districtId { get; set; }
        public int neighbourhoodId { get; set; }
        public int subNeighbourhoodId { get; set; }
        public int userId { get; set; }
        public DateTime listingDate { get; set; }
        public string latLong { get; set; }
    }
}
