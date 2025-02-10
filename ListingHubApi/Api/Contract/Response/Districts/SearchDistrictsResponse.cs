namespace Contract.Response.Districts
{
    public class SearchDistrictsResponse
    {
        public class District
        {
            public string name { get; set; }
            public int cityId { get; set; }
        }
        public SearchDistrictsResponse()
        {
            districts = new List<District>();
        }
        public  List<District> districts { get; set; }

    }
}
