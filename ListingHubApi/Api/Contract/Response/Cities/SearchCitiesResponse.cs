namespace Contract.Response.Cities
{
    public class SearchCitiesResponse
    {
        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public int plateCode { get; set; }
        }
        public SearchCitiesResponse()
        {
            cities = new List<City>();
        }
        public List<City> cities { get; set; }
    }
}
