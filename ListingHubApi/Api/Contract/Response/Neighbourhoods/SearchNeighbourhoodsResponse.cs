namespace Contract.Response.Neighbourhoods
{
    public class SearchNeighbourhoodsResponse
    {
        public class Neighbourhood
        {
            public int? districtId { get; set; }
            public string? name { get; set; }
        }
        public SearchNeighbourhoodsResponse()
        {
            neighbourhoods = new List<Neighbourhood>();
        }
        public IList<Neighbourhood> neighbourhoods { get; set; }
    }
}
